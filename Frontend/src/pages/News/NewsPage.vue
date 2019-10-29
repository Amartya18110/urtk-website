<template>
  <div class="news-root">
    <div class="nrw">
      <h1 class="news-title">{{title}}</h1>
      <div class="news-short">{{short}}</div>
      <div class="news-full" v-html="full"></div>
    </div>
  </div>
</template>

<script>
  export default {
    name: "NewsPage",
    created() {
      this.getNews();
    },
    data() {
      return {
        title: "",
        short: "",
        full: "",
        image: null,
        date: new Date()
      }
    },
    methods: {
      async getNews() {
        const response = await fetch(`http://localhost:${API_PORT}/news/getnews/${this.$route.params.id}`);
        const json = await response.json();
        let n = json;
        console.dir(n);
        this.title = n.newsName ? n.newsName : "";
        this.short = n.newsShortText ? n.newsShortText : "";
        this.full = n.newsFullText ? n.newsFullText : "";
        this.image = n.newsImage ? n.newsImage : "";
        this.date = n.newsCreateTime ? new Date(n.newsCreateTime) : null
      }
    }
  }
</script>

<style scoped>
  .nrw {
    padding: 0 10vw;
  }

  .news-title {
    font-size: 1.8em;
  }

  .news-short {
    font-size: 1.2em;
  }

  .news-full {
    margin-top: 40px;
  }
</style>