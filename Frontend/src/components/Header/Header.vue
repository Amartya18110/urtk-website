<template>
  <header>
    <div class="logo-block">
      <div class="logo">logo</div>
      <div class="title-block">
        <span>Областной молодежный медиаквест</span><br>
        <span class="project-title">«Российский спорт»</span>
      </div>
    </div>
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
    padding: 20px 20px;
  }

  .logo-block {
    display: flex;
    align-items: center;
    color: white;
  }

  .title-block {
    margin-left: 16px;
  }

  .logo {
  }

  .project-title {
    font-size: 1.5em;
    font-weight: bold;
  }
</style>