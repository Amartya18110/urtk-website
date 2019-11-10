<template>
  <div class="root">
    <div class="block-header">
      <h1 class="title">О проекте</h1>
      <RouterButton to="/edit-about" class="edit-button" v-show="signedAs">Редактировать</RouterButton>
    </div>
    <div v-if="noText">
      <h1 class="no-about-text-message">Здесь ничего нет.</h1>
      <RouterButton to="/edit-about" class="add-about-button">Добавить описание проекта</RouterButton>
    </div>
    <div v-if="!noText" v-html="aboutText"></div>
  </div>
</template>

<script>
  import RouterButton from "../../components/RouterButton/RouterButton.vue";

  export default {
    name: "AboutPage",
    components: {RouterButton},
    created() {
      this.loadAboutText();
    },
    data() {
      return {
        signedAs: localStorage.signed_as,
        aboutText: "",
        noText: false
      }
    },
    methods: {
      async loadAboutText() {
        const response = await fetch(API_ADDRESS + 'about/get');
        if (response.status === 200) {
          const about = await response.json();
          this.aboutText = about.aboutFullText;
        } else {
          this.noText = true;
        }
      }
    }
  }
</script>

<style scoped lang="scss">
  .root {
    padding: 0 20vw;
  }

  .title-wrapper {
    margin-top: 20px;
    display: flex;
    align-items: center;
  }

  .edit-button {
    margin-left: 50px;
  }

  .no-about-text-message {
    margin-top: 200px;
    text-align: center;
  }

  .add-about-button {
    display: block;
    margin: 40px auto 0 auto;
  }

  @media (max-width: 768px) {
    .block-header {
      text-align: center;
      flex-direction: column;

      h1 {
        font-size: 1.5em;
      }
    }

    .edit-button {
      margin-left: 0;
      margin-bottom: 30px;
    }
  }
</style>