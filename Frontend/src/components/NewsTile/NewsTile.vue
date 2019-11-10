<template>
  <router-link :to="`/news/${id}`" class="tile" :class="{ 'size-small': isSmall }">
    <div class="img-wrapper">
      <img :src="imageScr" :alt="title">
    </div>
    <div>
      <div class="title">{{ title }}</div>
      <div class="subtitle" v-if="!isSmall">{{ shortDecs }}</div>
      <div class="date">{{ formattedDate }}</div>
    </div>
  </router-link>
</template>

<script>
  export default {
    name: "NewsTile",
    props: {
      id: Number,
      title: String,
      shortDecs: String,
      imageScr: String,
      date: Date,
      isSmall: Boolean
    },
    computed: {
      formattedDate() {
        const formatter = new Intl.DateTimeFormat("ru", {
          year: "numeric",
          month: "long",
          day: "numeric",
          hour: "numeric",
          minute: "numeric"
        });
        return formatter.format(this.date);
      }
    }
  }
</script>

<style scoped lang="scss">
  @import "common.scss";

  .tile {
    cursor: pointer;
    display: block;
    transition: 200ms;
  }

  .tile:active {
    background: rgba(0,0,0,0.1);
  }

  .tile:hover {
    .img-wrapper img {
      width: 105%;
    }
  }

  .tile:active {
    .title {
      color: $primary-color;
    }
  }

  .img-wrapper {
    overflow: hidden;
    position: relative;
    padding-top: 60%;
  }

  .img-wrapper img {
    display: block;
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%,-50%);
    width: 100%;
    transition: 0.4s;
  }

  .title {
    margin-top: 8px;
    font-size: 1.3em;
    font-weight: bold;
    /*transition: 0.4s;*/
  }

  .subtitle {
    margin: 8px 0;
  }

  .date {
    color: $implicit-color;
    font-size: 0.9em;
  }

  .tile.size-small {
    display: flex;

    $img-size: 20%;
    .img-wrapper {
      flex-shrink: 0;
      flex-basis: $img-size;
      padding-top: $img-size;
      margin-right: 16px;
    }

    .title {
      font-size: 1em;
    }
  }
</style>