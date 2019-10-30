<template>
  <header>
    <router-link class="go-home" to="/">
      <div class="logo-block">
        <div class="logo">logo</div>
        <div class="title-block">
          <span>Областной молодежный медиаквест</span><br>
          <span class="project-title">«Российский спорт»</span>
        </div>
      </div>
    </router-link>
    <NavigationMenu></NavigationMenu>
  </header>
</template>

<script>
  import NavigationMenu from "../NavigationMenu/NavigationMenu.vue";
  export default {
    name: "Header",
    components: {NavigationMenu}
  }
</script>

<style scoped lang="scss">
  @import "common.scss";

  header {
    background: linear-gradient(180deg, $primary-color, lighten($primary-color, 5%));
    display: flex;
    justify-content: space-between;
    align-items: center;
  }

  .logo-block {
    display: flex;
    align-items: center;
    color: white;
    padding: 20px;
  }

  .title-block {
    margin-left: 16px;
  }

  .project-title {
    font-size: 1.5em;
    font-weight: bold;
  }

  .go-home:active {
    background: rgba(0, 0, 0, 0.1);
  }
</style>