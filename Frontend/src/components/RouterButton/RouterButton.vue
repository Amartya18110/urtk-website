<template>
  <router-link :to="to">
    <ActionButton class="button">
      <slot></slot>
    </ActionButton>
  </router-link>
</template>

<script>
  import ActionButton from "../ActionButton/ActionButton.vue";
  export default {
    name: "RouterButton",
    props: {
      to: String
    },
    components: {ActionButton}
  }
</script>

<style scoped>
  .button {
    margin: 0 auto;
  }
</style>