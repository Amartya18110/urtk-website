<template>
  <header>
    <div class="logo">logo</div>
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
    background: $primary-color;
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 20px 20px;
  }

  .logo {
    color: white;
  }
</style>