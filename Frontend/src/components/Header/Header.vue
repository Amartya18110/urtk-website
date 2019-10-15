<template>
  <header>
    <div class="logo">logo</div>
    <div class="menu">
      <ul>
        <li><router-link to="/home">Главная</router-link></li>
        <li><router-link to="/about">О проекте</router-link></li>
      </ul>
    </div>
  </header>
</template>

<script>
  export default {
    name: "Header"
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

  .menu {
    // TODO: выделить меню в одтельный компонент
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
  }
</style>