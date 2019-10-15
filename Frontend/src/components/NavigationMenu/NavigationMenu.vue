<template>
  <div class="menu">
    <ul>
      <li><router-link to="/home">Главная</router-link></li>
      <li><router-link to="/about">О проекте</router-link></li>
    </ul>
  </div>
</template>

<script>
  export default {
    name: "NavigationMenu"
  }
</script>

<style scoped lang="scss">
  @import "common.scss";

  $menu-button-padding: 10px;
  $menu-button-underline-height: 3px;

  ul {
    margin: 0;
    padding: 0;
    display: flex;
  }

  li {
    list-style-type: none;
    font-weight: bold;
  }

  a {
    padding: $menu-button-padding;
    display: block;
    color: white;
    transition: 0.2s;
  }

  a:active {
    color: $primary-color;
    background: white;
    border-radius: 5px;
  }

  a.router-link-active {
    padding-bottom: $menu-button-padding - $menu-button-underline-height;
    border-bottom: $menu-button-underline-height solid white;
  }
</style>