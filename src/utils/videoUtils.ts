import VideoService from "../services/videoService"
import { PrismaClient } from "@prisma/client";

const updateVideo = async () => {
    const videoService = new VideoService();

    const video = await videoService.getLatestVideos();

    //Update the prisma databas
    const prisma = new PrismaClient();

    // Check if there is a video in the database
    const videoInDatabase = await prisma.video.findMany({
        where: {
            videoId: video.id.videoId,
        },
    });

    // If there is no video in the database, create a new one
    if (videoInDatabase.length === 0) {
        await prisma.video.create({
            data: {
                videoId: video.id.videoId,
                title: video.snippet.title,
                publishedAt: video.snippet.publishedAt,
                thumbnailURL: video.snippet.thumbnails.high.url,
            },
        });
    }
}

export default updateVideo;