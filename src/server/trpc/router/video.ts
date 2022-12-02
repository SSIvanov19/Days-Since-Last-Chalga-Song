import { z } from "zod";
import updateVideo from "../../../utils/videoUtils";
import { router, publicProcedure } from "../trpc";

const videoSchema = z.object({
  videoId: z.string()
});

export const videoRouter = router({
  getLatestVideo: publicProcedure.query(async ({ ctx }) => {
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

      return input;
    }),
});
