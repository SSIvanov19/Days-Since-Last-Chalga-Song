
import updateVideo from "../../../utils/videoUtils";
import { router, publicProcedure } from "../trpc";

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
        // check if request is authorized with secret key)

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
});