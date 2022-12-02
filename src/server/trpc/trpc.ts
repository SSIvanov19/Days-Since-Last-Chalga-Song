import { initTRPC } from "@trpc/server";
import type { OpenApiMeta } from "trpc-openapi";
import superjson from "superjson";

import { type Context } from "./context";

const t = initTRPC.meta<OpenApiMeta>().context<Context>().create({
  transformer: superjson,
  errorFormatter({ shape }) {
    return shape;
  },
});

export const router = t.router;

export const publicProcedure = t.procedure;
