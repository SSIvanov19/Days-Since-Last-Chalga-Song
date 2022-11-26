import { type NextPage } from "next";
import Head from "next/head";
import Image from "next/image";
import { calculateDaysBetwenDates } from "../utils/time";
import { trpc } from "../utils/trpc";

const Home: NextPage = () => {
  const videoQuery = trpc.videos.getLatestVideo.useQuery();

  return (
    <>
      <Head>
        <title>Days Since Last Chalga Song</title>
        <meta name="description" content="Change me pls!" />
        <link rel="icon" href="/favicon.ico" />
        <meta name = "viewport" content = "width=device-width, initial-scale = 1, shrink-to-fit = no" />
        <meta name = "theme-color" content = "#2e026d"/>
        <meta name = "apple-mobile-web-app-capable" content = "yes" />
        <meta name = "apple-mobile-web-app-status-bar-style" content = "black-translucent" />
      </Head>
      <main className="grid gap-1 h-screen w-screen place-items-center bg-gradient-to-b from-[#2e026d] to-[#15162c] text-white">
        <div className="grid place-items-center text-center">
          <h1 className="mt-8 text-5xl font-bold">
            Days since last chalga song:
          </h1>
          <h1 className="mt-4 text-9xl font-bold">{calculateDaysBetwenDates(new Date(Date.now()), videoQuery.data?.publishedAt) }</h1>
        </div>
        {
          /*This will be a component in the future*/
          // A windows that shows the thumbnail of the last chalga song
        }
        <a
          href={"https://www.youtube.com/watch?v=" + videoQuery.data?.videoId}
          target="_blank"
          rel="noreferrer"
        >
          <div className="mt-8 grid w-screen justify-items-center text-black">
            <div className="flex sm:flex-row flex-col h-80 w-4/5 items-center rounded-3xl bg-white sm:pl-7 sm:h-44 md:w-7/12 ">
              <Image
                src={videoQuery.data?.thumbnailURL}
                alt="Video Thumbnail"
                width={480}
                height={360}
                className="h-[56z%] w-60 rounded-md mt-3 mb-3 sm:mt-0 sm:mb-0 sm:w-44"
              />
              <div className="ml-4 grid gap-3 ">
                <h1 className="text-md mq mt-2 mr-7 truncate font-bold lg:text-2xl">
                  {videoQuery.data?.title}
                </h1>
                <div className="flex">
                  <h1 className="text-md lg:text-xl">
                    Release date: {videoQuery.data?.publishedAt.toLocaleDateString()}
                  </h1>
                  <h1 className="text-md ml-7 mr-7 lg:text-xl">
                    Views: 100,000,000
                  </h1>
                </div>
              </div>
            </div>
          </div>
        </a>
        {/*
        <div className="relative overflow-auto rounded-xl pt-8">
          <div className="flex justify-center">
            <div className="flex h-10 w-10 animate-bounce items-center justify-center rounded-full bg-white p-2 shadow-lg ring-1 ring-slate-900/5 dark:bg-slate-800 dark:ring-slate-200/20">
              <svg
                className="h-6 w-6 text-violet-500"
                fill="none"
                strokeLinecap="round"
                strokeLinejoin="round"
                strokeWidth="2"
                viewBox="0 0 24 24"
                stroke="currentColor"
              >
                <path d="M19 14l-7 7m0 0l-7-7m7 7V3"></path>
              </svg>
            </div>
          </div>
        </div>
      */}
      </main>
    </>
  );
};

export default Home;
