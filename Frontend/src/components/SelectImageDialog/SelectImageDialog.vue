<template>
  <div class="insert-picture-dialog">
    <div class="dialog">
      <div class="dialog-header">
        <h1>Выбор изображения</h1>
      </div>
      <div class="dialog-content">
        <label class="dialog-image" :class="{ 'border': !hasImage }" @dragover.prevent.stop @drop.prevent.stop="fileDropped">
          <img :src="image" class="news-image-img">
          <div class="image-text select-image" v-show="!hasImage">Выбрать изображение</div>
          <input hidden type="file" @change="fileChanged">
        </label>
      </div>
      <div class="dialog-button-bar">
        <button class="cancel-button dialog-button" @click="onCancel">Отмена</button>
        <button class="insert-button dialog-button" @click="onOk">Вставить изображение</button>
      </div>
    </div>
  </div>
</template>

<script>
  // TODO: вынести выбор файла в отдельный компонент
  export default {
    name: "SelectImageDialog",
    data() {
      return {
        image: null,
      }
    },
    computed: {
      hasImage() {
        return this.image != null && this.image !== ""
      }
    },
    methods: {
      onOk() {
        this.$emit('image-changed', this.image);
        this.image = null;
      },
      onCancel() {
        this.$emit('image-changed', null);
        this.image = null;
      },
      fileDropped(event) {
        if (event) {
          const file = (event.dataTransfer || event.target).files[0];
          this.uploadFile(file);
        }
      },
      fileChanged(event) {
        if (event) {
          const file = event.target.files[0];
          this.uploadFile(file);
        }
      },
      async uploadFile(file) {
        if (file) {
          const formData = new FormData();
          formData.append("file", file);
          const response = await fetch(API_ADDRESS + 'news/UploadImage', {
            method: 'POST',
            mode: 'no-cors',
            body: formData
          });
          const fileSrc = await response.text();
          this.image = API_ADDRESS + fileSrc;
        }
      }
    }
  }
</script>

<style lang="scss" scoped>
  @import "common.scss";

  .dialog-image {
    display: block;
    cursor: pointer;
    width: 100%;
    height: 300px;
    flex-shrink: 0;
    box-sizing: border-box;
    position: relative;
  }

  .dialog-image.border {
    border: 4px dashed #aaa;
  }

  .image-text {
    padding: 0 20px;
    text-align: center;
    color: #aaaaaa;
    position: absolute;
    left: 0;
    top: 50%;
    right: 0;
    transform: translateY(-50%);
  }

  .news-image-img {
    width: 100%;
  }

  .insert-picture-dialog {
    position: absolute;
    left: 0;
    top: 0;
    right: 0;
    bottom: 0;
    background: rgba(0, 0, 0, 0.38);
  }

  .dialog-content {
    margin-bottom: 20px;
  }

  .dialog {
    background: white;
    padding: 20px;
    border-radius: 5px;
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
  }

  .dialog-button-bar {
    display: flex;
    justify-content: flex-end;
  }

  .dialog-button {
    cursor: pointer;
    display: block;
    padding: 4px 10px;
    border-radius: 5px;
    border: 1px solid $primary-color;
    transition: 0.1s;
    background: transparent;

  &:active {
     color: white;
     background: $primary-color;
   }

  &:focus {
     outline: none;
   }
  }

  .dialog-button:not(:last-child) {
    margin-right: 10px;
  }
</style>