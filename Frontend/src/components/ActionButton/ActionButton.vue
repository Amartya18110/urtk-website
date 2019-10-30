<template>
  <button class="button" @click="$emit('click', $event)">
    <slot></slot>
  </button>
</template>

<script>
  export default {
    name: "ActionButton"
  }
</script>

<style lang="scss" scoped>
  @import "common.scss";

  .button {
    user-select: none;
    font-size: 16px;
    cursor: pointer;
    display: block;
    padding: 6px 12px;
    border-radius: 5px;
    border: 1px solid $primary-color;
    background: transparent;

    &:active {
      color: white;
      background: $primary-color;
    }

    &:focus {
      outline: none;
    }
  }
</style>