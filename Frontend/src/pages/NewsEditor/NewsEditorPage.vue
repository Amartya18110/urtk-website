<template>
  <div class="editor">
    <div class="editor-header block-header">
      <h1>Добавление новости</h1>
      <a @click.prevert="save" class="save-button">Сохранить</a>
    </div>
    <div class="news-info">
      <label class="news-image" :class="{ 'border': !hasImage }" @dragover.prevent.stop @drop.prevent.stop="fileDropped">
        <img :src="editingNews.image" class="news-image-img">
        <div class="image-text" v-show="showDragMessage">Перетяните изображение сюда</div>
        <div class="image-text select-image" v-show="!hasImage">Выбрать изображение</div>
        <input hidden type="file" @change="fileChanged">
      </label>
      <div class="news-titles">
        <div class="news-title">
          <input type="text" placeholder="Заголовок" v-model="editingNews.title">
        </div>
        <div class="news-short">
          <textarea placeholder="Подзаголовок" v-model="editingNews.short"></textarea>
        </div>
      </div>
    </div>
    <div class="news-content-wrapper">
      <div class="news-content" contenteditable="true">
        Содержимое новости
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: "NewsEditor",
    data() {
      return {
        showDragMessage: false,
        editingNews: {
          title: "",
          short: "",
          image: null
        }
      }
    },
    computed: {
      hasImage() {
        return this.editingNews.image != null && this.editingNews.image !== ""
      }
    },
    methods: {
      onEditorDragover() {
        console.log("dragover");
        this.showDragMessage = true;
      },
      onEditorDragend() {
        this.showDragMessage = false;
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
      pass(event) {
        if (event) {
          console.log("kek");
        }
      },
      async uploadFile(file) {
        if (file) {
          const formData = new FormData();
          formData.append("file", file);
          console.dir(file);
          console.dir(formData);
          const response = await fetch(`http://localhost:${API_PORT}/news/UploadImage`, {
            method: 'POST',
            body: formData
          });
          const fileSrc = await response.text();
          console.log(fileSrc);
          this.editingNews.image = `http://localhost:${API_PORT}/${fileSrc.replace(/\\/g, '/')}`
        }
      },
      async save(event) {
        const body = {
          "NewsName": this.editingNews.title,
          "NewsShortText": this.editingNews.short,
          "NewsFullText": document.querySelector('.news-content').innerHTML
        };
        const response = await fetch(`http://localhost:${API_PORT}/news/addnews`, {
          method: 'POST',
          headers: {
            'content-type': 'application/json'
          },
          body: JSON.stringify(body)
        });
        const json = await response.json();
        const id = json.id;
        await this.$router.push(`/news/${id}`);
      }
    }
  }
</script>

<style lang="scss" scoped>
  @import "common.scss";

  .editor {
    padding: 0 10vw;
  }

  .block-header {
    display: flex;
    align-items: center;
  }

  .save-button {
    cursor: pointer;
    display: block;
    margin-left: 50px;
    padding: 4px 10px;
    border-radius: 5px;
    border: 1px solid $primary-color;
    transition: 0.4s;

    &:active {
      color: white;
      background: $primary-color;
    }
  }

  .news-info {
    display: flex;
  }

  .news-image {
    cursor: pointer;
    width: 200px;
    height: 166px;
    flex-shrink: 0;
    margin-right: 30px;
    box-sizing: border-box;
    position: relative;
  }

  .news-image.border {
    border: 4px dashed #aaa;
  }

  .image-text {
    padding: 0 20px;
    text-align: center;
    color: #aaaaaa;
    position: absolute;
    top: 50%;
    transform: translateY(-50%);
  }

  .news-image-img {
    width: 200px;
  }

  .news-titles {
    width: 100%;
  }

  .news-title {
    input {
      font-size: 1.8em;
    }
  }

  .news-short {
    margin-top: 20px;
    textarea {
      font-size: 1.2em;
    }
  }

  input, textarea {
    width: 100%;
    border: none;
    resize: vertical;

    &:focus {
      outline: none;
    }
  }

  .news-content-wrapper {
    margin-top: 40px;
  }
</style>