import { z } from "zod";
import NotificationService from "../../../services/NotificationService";
import VideoService from "../../../services/videoService";
import updateVideo from "../../../utils/videoUtils";
import { router, publicProcedure } from "../trpc";

const videoSchema = z.object({
  videoURL: z.string(),
});

export const videoRouter = router({
  getLatestVideo: publicProcedure
    .input(z.object({}).optional())
    .output(z.any())
    .meta({
      openapi: {
        method: "GET",
        path: "/video/getLatestVideo",
      },
    })
    .query(async ({ ctx }) => {
      // get latest videos from database
      const videos = await ctx.prisma.video.findMany({
        orderBy: {
          publishedAt: "desc",
        },
        take: 1,
      });

      // return the latest video
      return videos[0];
    }),
  updateVideoList: publicProcedure.query(async ({ ctx }) => {
    // check if request is authorized with secret key
    // eslint-disable-next-line @typescript-eslint/ban-ts-comment
    //@ts-expect-error
    if (ctx.req?.headers.authorization !== process.env.SECRET_KEY) {
      return {
        error: "Not authorized",
      };
    }

    await updateVideo();

    return {
      message: "Updated video list",
    };
  }),
  // route that will get all the videos realeased within the last mount
  // get latest videos from database
  getVideosFromLastMonth: publicProcedure
    .input(z.number())
    .query(async ({ ctx, input }) => {
      const videos = await ctx.prisma.video.findMany({
        where: {
          publishedAt: {
            gte: new Date(new Date().setMonth(new Date().getMonth() - input)),
          },
        },
        orderBy: {
          publishedAt: "desc",
        },
      });

      // return the latest video
      return videos;
    }),
  addVideo: publicProcedure
    .input(videoSchema)
    .output(z.any())
    .meta({
      openapi: {
        method: "POST",
        path: "/video/add",
      },
    })
    .mutation(async ({ ctx, input }) => {
      // eslint-disable-next-line @typescript-eslint/ban-ts-comment
      //@ts-expect-error
      if (ctx.req?.headers.authorization !== process.env.SECRET_KEY) {
        return {
          error: "Not authorized",
        };
      }

      // get the video id from the url
      const videoId = input.videoURL.split("v=")[1];

      if (videoId === undefined) {
        return {
          error: "Invalid video url",
        };
      }
      
      const videoInDatabase = await ctx.prisma.video.findMany({
        where: {
          videoId: videoId,
        },
      });

      // If there is no video in the database, create a new one
      if (videoInDatabase.length !== 0) {
        return {
          error: "Video already exists",
        };
      }

      const videoService = new VideoService();

      const video = await videoService.getVideoInfo(videoId);
      
      if (await videoService.isShort(videoId)) {
        return {
          error: "Video is of type short",
        };
      }

      await ctx.prisma.video.create({
        data: {
          videoId: videoId,
          title: video.snippet.title,
          publishedAt: video.snippet.publishedAt,
          thumbnailURL: video.snippet.thumbnails.high.url,
          channelTitle: video.snippet.channelTitle,
        },
      });
      
      const notificationService = new NotificationService();

      await notificationService.sendNotification(
        video.snippet.title,
        video.snippet.channelTitle,
        video.snippet.thumbnails.high.url);

      return {
        message: "Video added",
      };
    }),
    getVideoBetweenDates: publicProcedure
    .input(z.object({
      startDate: z.string(),
      endDate: z.string()
    }))
    .output(z.any())
    .meta({
      openapi: {
        method: "GET",
        path: "/video/getVideoBetweenDates",
      },
    })
    .query(async ({ ctx, input }) => {
      const videos = await ctx.prisma.video.findMany({
        where: {
          publishedAt: {
            gte: new Date(input.startDate),
            lte: new Date(input.endDate)
          },
        },
        orderBy: {
          publishedAt: "desc",
        },
      });

      // return the latest video
      return videos;
    }),
    getVideoByVideoId: publicProcedure
    .input(z.object({
      videoId: z.string()
    }))
    .output(z.any())
    .meta({
      openapi: {
        method: "GET",
        path: "/video/getVideoByVideoId",
      },
    })
    .query(async ({ ctx, input }) => {
      const video = await ctx.prisma.video.findFirst({
        where: {
          videoId: input.videoId
        }
      });

      // return the latest video
      return video;
    }),
});
