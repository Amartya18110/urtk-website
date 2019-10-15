<template>
  <div>
    <Header></Header>
    <div class="pages-container">
      <router-view></router-view>
    </div>
  </div>
</template>

<script>
  import Header from "../Header/Header.vue";

  export default {
    name: 'App',
    components: {Header},
    data() {
      return {
        message: "Проект про спорт"
      }
    }
  }
</script>

<style scoped lang="scss">
  @import "common.scss";

  h1 {
    color: white;
    background: $primary-color;
  }
</style>