<template>
  <div class="news-root">
    <div class="news-image-wrapper">
      <img :src="image">
      <div class="news-image-f">
        <div class="news-date">{{formattedDate}}</div>
        <h1 class="news-title">{{title}}</h1>
        <div class="news-short">{{short}}</div>
      </div>
    </div>
    <div class="nrw">
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
    computed: {
      formattedDate() {
        const formatter = new Intl.DateTimeFormat("ru", {
          year: "numeric",
          month: "long",
          day: "numeric",
          hour: "numeric",
          minute: "numeric"
        });
        return formatter.format(this.date);
      }
    },
    methods: {
      async getNews() {
        const response = await fetch(`${API_HOST}:${API_PORT}/news/getnews/${this.$route.params.id}`);
        let n = await response.json();
        this.title = n.newsName ? n.newsName : "";
        this.short = n.newsShortText ? n.newsShortText : "";
        this.full = n.newsFullText ? n.newsFullText : "";
        this.image = n.newsImage ? n.newsImage : "";
        const formatter = Intl.DateTimeFormat("ru");
        this.date = n.newsCreateTime ? new Date(n.newsCreateTime) : null
      }
    }
  }
</script>

<style lang="scss" scoped>
  .news-image-wrapper {
    margin-top: -85px;
    position: relative;
    overflow: hidden;
    min-height: 85px;
    max-height: 400px;

    img {
      display: block;
      width: 100%;
    }
  }

  .news-image-f {
    position: absolute;
    left: 0;
    top: 0;
    right: 0;
    bottom: 0;
    background: rgba(0, 0, 0, 0.6);
    padding: 120px 20vw 60px 20vw;
    color: white;
  }

  .nrw {
    padding: 0 20vw;
  }

  .news-title {
    font-size: 2.4em;
  }

  .news-short {
    font-size: 1.2em;
  }

  .news-full {
    margin-top: 40px;
  }
</style>