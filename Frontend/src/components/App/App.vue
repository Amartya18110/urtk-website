<template>
  <div class="page">
    <Header class="page-header"></Header>
    <div class="pages-container">
      <router-view></router-view>
    </div>
    <Footer class="page-footer"></Footer>
  </div>
</template>

<script>
  import Header from "../Header/Header.vue";
  import Footer from "../Footer/Footer.vue";

  export default {
    name: 'App',
    components: {Footer, Header}
  }
</script>

<style scoped lang="scss">
  @import "common.scss";

  .page {
    min-height: 100%;
    display: flex;
    flex-direction: column;
  }

  .page-header, .page-footer {
    flex-shrink: 0;
    flex-grow: 0;
  }

  .pages-container {
    flex-grow: 1;
  }

  h1 {
    color: white;
    background: $primary-color;
  }
</style>