<template>
  <div class="insert-picture-dialog">
    <div class="dialog">
      <div class="dialog-header">
        <h1>Загрузка файла</h1>
      </div>
      <div class="dialog-content">
        <label class="name-label" v-show="file">
          Имя файла:
          <input class="name-input" type="text" v-model="fileName">
        </label>
        <label class="desc-label" v-show="file">
          Описание файла:
          <textarea class="desc-input" type="text" v-model="fileDesc"></textarea>
        </label>
        <input type="file" @change="fileChanged">
      </div>
      <div class="dialog-button-bar">
        <button class="cancel-button dialog-button" @click="onCancel">Отмена</button>
        <button class="insert-button dialog-button" @click="onOk">Сохранить файл</button>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: "UploadFileComponent",
    data() {
      return {
        file: null,
        fileName: "",
        fileDesc: "",
      }
    },
    methods: {
      onOk() {
        this.uploadFile(this.file);
      },
      onCancel() {
        this.$emit('file-rejected');
      },
      fileChanged(event) {
        if (event) {
          const file = event.target.files[0];
          this.file = file;
          this.fileName = file.name;
          this.fileDesc = "";
        }
      },
      async uploadFile(file) {
        if (file) {
          const formData = new FormData();
          formData.append("file", file);
          formData.append("documentName", this.fileName);
          formData.append("documentCaption", this.fileDesc);
          const response = await fetch(`${API_HOST}:${API_PORT}/document/UploadDocument`, {
            method: 'POST',
            mode: 'no-cors',
            body: formData
          });
          this.$emit('file-saved');
        }
      }
    }
  }
</script>

<style lang="scss" scoped>
  @import "common.scss";

  .dialog-file {
    display: block;
    cursor: pointer;
    width: 100%;
    height: 100px;
    flex-shrink: 0;
    box-sizing: border-box;
    position: relative;
  }

  .dialog-file.border {
    border: 4px dashed #aaa;
  }

  .file-text {
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
    min-width: 400px;
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

  .name-label {
    display: flex;
    align-items: center;
  }

  .name-input {
    margin-left: 10px;
    border: 1px solid $implicit-color;
    border-radius: 6px;
    padding: 6px 10px;
    flex-grow: 1;

    &:focus {
      outline: none;
      border-width: 2px;
      border-color: $primary-color;
      padding: 5px 9px;
    }
  }

  .desc-label {
    display: block;
    margin: 10px 0;
  }

  .desc-input {
    display: block;
    width: 100%;
    border: 1px solid $implicit-color;
    resize: vertical;

    &:focus {
      outline: none;
      border-width: 2px;
      border-color: $primary-color;
    }
  }
</style>