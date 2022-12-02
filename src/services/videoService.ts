// Might do a interface for this later
export default class VideoService {
  async getLatestVideos() {
    let videos: any = [];

    for (const id of this.channelsIds) {
      const req = await fetch(
        `https://www.googleapis.com/youtube/v3/search?part=snippet&channelId=${id}&maxResults=1&order=date&key=${this.apiKey}`
      );
      const json = await req.json();
      const videoInfo = json.items;
      videos = videos.concat(videoInfo);
    }

    // Find the latest video using date
    return videos.reduce((prev: any, current: any) => {
      return prev.snippet.publishedAt > current.snippet.publishedAt
        ? prev
        : current;
    });
  }

  async getVideoInfo(videoId: string) {
    const req = await fetch(
      `https://www.googleapis.com/youtube/v3/videos?part=snippet&id=${videoId}&key=${this.apiKey}`);

    const json = await req.json();
    return json.items[0];
  }

  private apiKey = process.env.YOUTUBE_API_KEY;
  private channelsIds = [
    "UCu3z3dIQNb90UNp6_w5O5rw",
    "UCffdZGxiVRy3i9EaZF4m0wA",
    "UCTimP1Fbgg5hXjYoPItRa-A",
    "UC7jQEL7g4i8BM5dLsgcidcw",
    "UCwxOx7KChxc7zZ9d6bKAvUw",
    "UCXRMs01s9wkmegkFqiiOuOw",
    "UC5Wy-frUjW5Pjqxi0xU-Fbw",
    "UCAvjic6NqR2EvjpGT4EyWeg",
    "UCYo2cFsn4NyVH3BF5PfzDkw",
    "UCvpZFKWxPY6mOt1n8eDNKQA",
    "UCS24D4x3HqJ4148WpDvSdnQ",
    "UCF436ipNCsiVZKwwTIXy-SA",
    "UCkM1YP-otoQKuT3GK_ahSnA",
    "UCg6l2EoIV3jjEZWrcQnmbpA",
    "UC9IevoiJWik1PrWepAR9avg",
    "UCBdH5-kA9DrBTDjMrAaisEg",
    "UCllCyxwQFmATHkbgVkiiYpA",
    "UCx1lEreLZXeNnr6QV4W0XaQ",
    "UCV3W7mNh33F4DM1SkdKYQNA",
    "UCwyO9cq2ILJki2suJcSRLNQ",
    "UCRMbl4v_fVLC7szAgWwyCTg",
    "UCQ7O7msY1UdQgM7Td36SvqQ",
    "UCwrRn-YlnOhbgSmVZHPMw8A",
    "UCZW6wX1ATmWR13R8Cj7wE4A",
  ];
}
