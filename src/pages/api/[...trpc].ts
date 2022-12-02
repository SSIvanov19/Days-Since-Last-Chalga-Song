import type { NextApiRequest, NextApiResponse } from 'next/types';
import { createOpenApiNextHandler } from 'trpc-openapi';
import { appRouter } from '../../server/trpc/router/_app';
import { createContext } from "../../server/trpc/context";

const handler = async (req: NextApiRequest, res: NextApiResponse) => {
    // Handle incoming OpenAPI requests
    return createOpenApiNextHandler({
      router: appRouter,
      createContext,
    })(req, res);
  };
  

export default handler;