/* eslint-disable @typescript-eslint/no-non-null-assertion */
/* eslint-disable @typescript-eslint/no-non-null-asserted-optional-chain */
import { type NextPage } from "next";
import Head from "next/head";
import Image from "next/image";
import { Line } from "react-chartjs-2";
import { calculateDaysBetwenDates } from "../utils/time";
import { trpc } from "../utils/trpc";
import {
  CategoryScale,
  Chart as ChartJS,
  LinearScale,
  LineElement,
  PointElement,
  Tooltip,
} from "chart.js";
import { useEffect, useState } from "react";

ChartJS.register(
  LinearScale,
  CategoryScale,
  PointElement,
  LineElement,
  Tooltip
);

const Home: NextPage = () => {
  const [publishDate, setPublishDate] = useState("");

  const videoQuery = trpc.videos.getLatestVideo.useQuery();
  const lastMountVideos = trpc.videos.getVideosFromLastMonth.useQuery(1);

  const daysBetwenTodayAndLastVideo = calculateDaysBetwenDates(
    new Date(Date.now()),
    videoQuery.data?.publishedAt!
  );
  const dates = (() => {
    const dates = [];

    for (let i = 0; i < 30; i++) {
      const date = new Date();
      date.setDate(date.getDate() - i);
      dates.push(date.toLocaleDateString());
    }

    return dates.reverse();
  })();

  useEffect(() => {
    if (videoQuery.data) {
      setPublishDate(videoQuery.data.publishedAt.toLocaleDateString());
    }
  }, [setPublishDate, videoQuery.data]);

  // Chart data with x being time and y being days for one mount
  const chartData = {
    labels: dates,
    datasets: [
      {
        label: "Videos",
        data: (() => {
          const days: number[] = [];
          let temp = 0;
          let flag = true;

          for (let i = daysBetwenTodayAndLastVideo; i >= 1; i--) {
            days.push(i);
          }

          for (const date of dates) {
            if (flag && temp < days.length) {
              temp++;
              continue;
            }

            // Find video uploaded on the same day
            const video = lastMountVideos.data?.find(
              (video) => video.publishedAt.toLocaleDateString() === date
            );

            if (video) {
              days.push(0);
            } else {
              days.push(days[days.length - 1]! + 1);
            }

            flag = false;
          }

          return days;
        })(),
        fill: true,
        backgroundColor: "rgb(255, 255, 255)",
        borderColor: "rgba(255, 255, 255, 0.6)",
      },
    ],
  };

  const chartOptions = {
    responsice: true,
    plugins: {
      title: {
        display: true,
        text: "Chart.js Line Chart",
      },
      tooltip: {
        mode: "index" as 'index',
        intersect: false,
        yAlign: "bottom" as 'bottom',
        displayColors: false,
        callbacks: {
          label: (tooltipItem: any) => {
            if (tooltipItem.raw != 0) {
              if (tooltipItem.raw == 1) {
                return "1 day since the last Chalga";
              }

              return `${tooltipItem.raw} days since the last Chalga`;
            }

            return (
              lastMountVideos.data
                ?.find(
                  (video) =>
                    video.publishedAt.toLocaleDateString() ===
                    dates[tooltipItem.dataIndex]
                )
                ?.title.slice(0, 30) + "..."
            );
          },
        },
      },
    },
    scales: {
      y: {
        beginAtZero: true,
        grid: {
          color: "rgba(255, 255, 255, 0.4)",
          borderColor: "white",
        },
        ticks: {
          stepSize: 1,
          color: "rgba(255, 255, 255, 0.8)",
        },
      },
      x: {
        grid: {
          display: false,
        },
        ticks: {
          stepSize: 1,
          color: "rgba(255, 255, 255, 0.8)",
        },
      },
    },
  };

  return (
    <>
      <Head>
        <title>Days Since Last Chalga Song</title>
        <meta
          name="description"
          content="Get the always up to date information about how many days have passed since a Chalga song has been released!"
        />
        <link rel="icon" href="/favicon.ico" />
        <meta
          name="viewport"
          content="width=device-width, initial-scale = 1, shrink-to-fit = no"
        />
        <meta name="theme-color" content="#2e026d" />
        <meta name="apple-mobile-web-app-capable" content="yes" />
        <meta
          name="apple-mobile-web-app-status-bar-style"
          content="black-translucent"
        />
      </Head>
      <main className="bg-gradient-to-b from-[#2e026d] to-[#15162c] text-white">
        <div className="grid h-screen w-screen place-items-center gap-1">
          <div className="grid place-items-center text-center">
            <h1 className="mt-8 text-5xl font-bold">
              Days since last chalga song:
            </h1>
            <h1 className="mt-4 text-9xl font-bold">
              {daysBetwenTodayAndLastVideo}
            </h1>
          </div>
          {
            /*This will be a component in the future*/
            // A windows that shows the thumbnail of the last chalga song
          }
          <div className="mt-8 grid w-screen justify-items-center text-black">
            <a
              href={
                "https://www.youtube.com/watch?v=" + videoQuery.data?.videoId
              }
              target="_blank"
              rel="noreferrer"
              className="flex h-80 w-4/5 flex-col items-center rounded-3xl bg-white sm:h-44 sm:flex-row sm:pl-7 md:w-7/12 "
            >
              <Image
                src={videoQuery.data?.thumbnailURL!}
                alt="Video Thumbnail"
                width={480}
                height={360}
                className="mt-3 mb-3 h-[56z%] w-60 rounded-md sm:mt-0 sm:mb-0 sm:w-44"
              />
              <div className="ml-4 grid gap-3 ">
                <h1 className="text-md mq mt-2 mr-7 truncate font-bold lg:text-2xl">
                  {videoQuery.data?.title}
                </h1>
                <div className="flex">
                  <h1 className="text-md lg:text-xl">
                    Release date: {publishDate}
                  </h1>
                  <h1 className="text-md ml-7 mr-7 lg:text-xl"></h1>
                </div>
              </div>
            </a>
          </div>
          <div className="relative overflow-auto rounded-xl pt-8">
            <div className="flex justify-center">
              <a
                href="#chart"
                className="flex h-10 w-10 animate-bounce items-center justify-center rounded-full bg-white p-2 shadow-lg ring-1 ring-slate-900/5 dark:bg-slate-800 dark:ring-slate-200/20"
              >
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
              </a>
            </div>
          </div>
        </div>
        <div className="flex items-center justify-center pt-12 pb-24">
          <div className="sm:h=1/2 h-full w-full pr-3 sm:w-1/2 sm:pr-0">
            <Line id="chart" data={chartData} options={chartOptions} />
          </div>
        </div>
      </main>
    </>
  );
};

export default Home;
