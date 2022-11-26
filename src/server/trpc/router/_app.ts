import { router } from "../trpc";
import { exampleRouter } from "./example";
import { videoRouter } from "./video";

export const appRouter = router({
  example: exampleRouter,
  videos: videoRouter,
});

// export type definition of API
export type AppRouter = typeof appRouter;
