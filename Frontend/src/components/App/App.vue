<template>
    <h1>{{message}}</h1>
</template>

<script>
    export default {
      name: 'App',
      data() {
        return {
          message: "Проект про спорт"
        }
      }
    }
</script>

<style scoped lang="scss">
    h1 {
        color: coral;
    }
</style>