<template>
  <a class="file-view" download="true" :href="fullLink">
    <div class="file-image"></div>
    <div class="file-attrs">
      <div class="file-name">{{ name }}</div>
      <div class="file-desc">{{ desc }}</div>
      <div class="file-date">{{ formattedDate }}</div>
    </div>
  </a>
</template>

<script>
  export default {
    name: "FileView",
    props: {
      src: String,
      name: String,
      desc: String,
      date: Date
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
      },
      fullLink() {
        return API_ADDRESS + this.src;
      },
      extention() {
        if (this.src != null && this.src !== "") {
          const lastDot = this.src.lastIndexOf('.');
          return this.src.substring(lastDot + 1);
        }

        return 'file';
      }
    }
  }
</script>

<style scoped lang="scss">
  .file-view {
    background: #efefef;
    padding: 10px;
    border-radius: 8px;
    display: flex;
    align-items: center;
    overflow: hidden;
    transition: 200ms;
  }

  .file-image {
    width: 55px;
    height: 55px;
    flex-grow: 0;
    flex-shrink: 0;
    border-radius: 50%;
    background: white url("./file.svg") no-repeat center center / 22px;
    transition: 300ms;
  }

  .file-view:hover {
    .file-image {
      background-image: url("./download.svg");
    }
  }

  .file-view:active {
    background: #dddddd;
  }

  .file-attrs {
    margin-left: 10px;
  }

  .file-name {
    font-weight: bold;
    word-break: break-all;
  }

  .file-desc {}

  .file-date {
    font-size: 0.8em;
    opacity: 0.6;
  }
</style>