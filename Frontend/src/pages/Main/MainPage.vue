<template>
  <div class="root-block">
    <h1>Последние события</h1>
    <div class="news-list">
      <NewsTile v-for="news in newsList.slice(0, 2)"
                :key="news.id"
                :id="news.id"
                :title="news.title"
                :short-decs="news.shortDesc"
                :image-scr="news.headlineImageUrl"
                :date="news.date">
      </NewsTile>
      <div class="additional-news">
        <h2 class="additional-news-title">Другие новости</h2>
        <NewsTile v-for="news in newsList.slice(2, 6)"
                  class="additional-news-item"
                  :key="news.id"
                  :id="news.id"
                  :is-small="true"
                  :title="news.title"
                  :short-decs="news.shortDesc"
                  :image-scr="news.headlineImageUrl"
                  :date="news.date">
        </NewsTile>
        <router-link class="i-want-read-more-boring-news-button" to="/news">К другим новостям</router-link>
      </div>
    </div>
  </div>
</template>

<script>
  import NewsTile from "../../components/NewsTile/NewsTile.vue";
  export default {
    name: "MainPage",
    components: {NewsTile},
    data() {
      return {
        // TODO: это пока нет API, переделать
        newsList: [
          {
            id: 1,
            views: 120,
            title: "Итоги недели: матч сборных России и Польши на «Екатеринбург Арене»",
            shortDesc: "О главном спортивном событии недели. Сборные России и Польши по футболу сыграли на Екатеринбург-арене.",
            date: new Date(),
            headlineImageUrl: "https://www.dw.com/image/17804930_303.jpg"
          },
          {
            id: 2,
            views: 101,
            title: "Министр спорта РФ прокомментировал слова Гануса в иностранных СМИ",
            shortDesc: "",
            date: new Date(),
            headlineImageUrl: "https://avatars.mds.yandex.net/get-ynews/2425176/394cbd8ecaad75faedb57a723c352d0d/563x304"
          },
          {
            id: 3,
            views: 120,
            title: "Итоги недели: матч сборных России и Польши на «Екатеринбург Арене»",
            shortDesc: "О главном спортивном событии недели. Сборные России и Польши по футболу сыграли на Екатеринбург-арене.",
            date: new Date(),
            headlineImageUrl: "https://www.dw.com/image/17804930_303.jpg"
          },
          {
            id: 4,
            views: 101,
            title: "Министр спорта РФ прокомментировал слова Гануса в иностранных СМИ",
            shortDesc: "",
            date: new Date(),
            headlineImageUrl: "https://avatars.mds.yandex.net/get-ynews/2425176/394cbd8ecaad75faedb57a723c352d0d/563x304"
          },
          {
            id: 5,
            views: 120,
            title: "Итоги недели: матч сборных России и Польши на «Екатеринбург Арене»",
            shortDesc: "О главном спортивном событии недели. Сборные России и Польши по футболу сыграли на Екатеринбург-арене.",
            date: new Date(),
            headlineImageUrl: "https://www.dw.com/image/17804930_303.jpg"
          },
          {
            id: 6,
            views: 101,
            title: "Министр спорта РФ прокомментировал слова Гануса в иностранных СМИ",
            shortDesc: "",
            date: new Date(),
            headlineImageUrl: "https://avatars.mds.yandex.net/get-ynews/2425176/394cbd8ecaad75faedb57a723c352d0d/563x304"
          },
          {
            id: 7,
            views: 120,
            title: "Итоги недели: матч сборных России и Польши на «Екатеринбург Арене»",
            shortDesc: "О главном спортивном событии недели. Сборные России и Польши по футболу сыграли на Екатеринбург-арене.",
            date: new Date(),
            headlineImageUrl: "https://www.dw.com/image/17804930_303.jpg"
          },
          {
            id: 8,
            views: 101,
            title: "Министр спорта РФ прокомментировал слова Гануса в иностранных СМИ",
            shortDesc: "",
            date: new Date(),
            headlineImageUrl: "https://avatars.mds.yandex.net/get-ynews/2425176/394cbd8ecaad75faedb57a723c352d0d/563x304"
          },
          {
            id: 9,
            views: 120,
            title: "Итоги недели: матч сборных России и Польши на «Екатеринбург Арене»",
            shortDesc: "О главном спортивном событии недели. Сборные России и Польши по футболу сыграли на Екатеринбург-арене.",
            date: new Date(),
            headlineImageUrl: "https://www.dw.com/image/17804930_303.jpg"
          },
          {
            id: 10,
            views: 101,
            title: "Министр спорта РФ прокомментировал слова Гануса в иностранных СМИ",
            shortDesc: "",
            date: new Date(),
            headlineImageUrl: "https://avatars.mds.yandex.net/get-ynews/2425176/394cbd8ecaad75faedb57a723c352d0d/563x304"
          },
        ].slice(0, 9)
      }
    }
  }
</script>

<style scoped lang="scss">
  @import "common.scss";

  .root-block {
    padding: 0 10vw;
  }

  .news-list {
    display: grid;
    grid-template-columns: repeat(3, 1fr);
    grid-gap: 1vw;
  }

  .additional-news {
    grid-row: 1 / 3;
    grid-column: 3;
    padding: 10px;
    background: #f5f3f3;
  }

  .additional-news-title {
    margin: 0;
  }

  .additional-news-item {
    margin-top: 16px;
  }

  .i-want-read-more-boring-news-button {
    display: inline-block;
    margin-top: 16px;
    color: $implicit-color;
    border-bottom: $implicit-color 1px solid;
    transition: 0.4s;

    &::before, &::after {
      transition: 0.4s transform;
      display: inline-block;
      content: '→';
    }

    &::before {
      transition: 0.4s opacity, 0.4s width;
      width: 0;
      opacity: 0;
    }

    &:hover {
      color: $primary-color;
      border-bottom-color: $primary-color;

      &:before {
        width: 16px;
        opacity: 1;
      }

      &:after {
        transform: scaleX(-1);
      }
    }
  }
</style>