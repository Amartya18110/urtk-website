<template>
  <div class="root-block">
    <div class="block-header">
      <h1>Последние события</h1>
      <RouterButton v-show="signedAs" class="header-add-button" to="/add-news">Добавить новость</RouterButton>
    </div>
    <div class="news-list">
      <NewsTile v-for="news in newsList.slice(0, 2)"
                :key="news.id"
                :id="news.id"
                :title="news.title"
                :short-decs="news.short"
                :image-scr="news.image"
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
                  :short-decs="news.short"
                  :image-scr="news.image"
                  :date="news.date">
        </NewsTile>
        <router-link class="i-want-read-more-boring-news-button" to="/news">К другим новостям</router-link>
      </div>
    </div>
    <div class="block-header">
      <h1>Документы</h1>
      <UploadFileComponent @file-changed="onFileSaved" v-show="showFileUploadDialog"></UploadFileComponent>
      <ActionButton class="header-add-button" v-show="signedAs" @click="openAddFileDialog">Загрузить документ</ActionButton>
    </div>
  </div>
</template>

<script>
  import NewsTile from "../../components/NewsTile/NewsTile.vue";
  import ActionButton from "../../components/ActionButton/ActionButton.vue";
  import UploadFileComponent from "../../components/UploadFileDialog/UploadFileComponent.vue";
  import RouterButton from "../../components/RouterButton/RouterButton.vue";
  export default {
    name: "MainPage",
    components: {RouterButton, UploadFileComponent, ActionButton, NewsTile},
    created() {
      this.getFilesList();
      this.getNewsList();
    },
    data() {
      return {
        showFileUploadDialog: false,
        signedAs: localStorage.signed_as,
        newsList: []
      }
    },
    methods: {
      openAddFileDialog() {
        this.showFileUploadDialog = true;
      },
      onFileSaved() {
        this.getFilesList();
        this.showFileUploadDialog = false;
      },
      onFileRejected() {
        this.showFileUploadDialog = false;
      },
      async getNewsList() {
        const response = await fetch(`${API_HOST}:${API_PORT}/news/getnews?page=1&pageSize=6`);
        const json = await response.json();
        this.newsList = json.news.map(n => {
          return {
            id: n.id,
            title: n.newsName ? n.newsName : "",
            short: n.newsShortText ? n.newsShortText : "",
            full: n.newsFullText ? n.newsFullText : "",
            image: n.newsImage ? n.newsImage : "",
            date: n.newsCreateTime ? new Date(n.newsCreateTime) : null
          };
        });
      },
      async getFilesList() {
        console.log("кто-то забыл сделать API!");
      }
    }
  }
</script>

<style scoped lang="scss">
  @import "common.scss";

  .root-block {
    padding: 0 10vw;
  }

  .block-header {
    display: flex;
    align-items: center;
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

  .header-add-button {
    margin-left: 50px;
  }
</style>