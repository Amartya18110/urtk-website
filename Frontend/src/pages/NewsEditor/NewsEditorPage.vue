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
      <div class="editor-toolbar">
        <img class="toolbar-button button-bold" @click.prevent.stop="format('bold')" src="dist/img/bold.svg" alt="bold">
        <img class="toolbar-button button-bold" @click.prevent.stop="format('italic')" src="dist/img/italic.svg" alt="italic">
        <img class="toolbar-button button-bold" @click.prevent.stop="format('underline')" src="dist/img/underline.svg" alt="underline">
        <img class="toolbar-button button-bold" @click.prevent.stop="openPictureInsertDialog" src="dist/img/pic.svg" alt="picture">
      </div>
      <SelectImageDialog @image-changed="onPictureInsertDialogClosed" v-show="showImageDialog"></SelectImageDialog>
      <div class="news-content" contenteditable="true">
        Содержимое новости
      </div>
    </div>
  </div>
</template>

<script>
  import SelectImageDialog from "../../components/SelectImageDialog/SelectImageDialog.vue";
  export default {
    name: "NewsEditor",
    components: {SelectImageDialog},
    data() {
      return {
        showImageDialog: false,
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
      format(cmd) {
        document.execCommand(cmd, false, null);
        document.querySelector('.news-content').focus();
      },
      openPictureInsertDialog(event) {
        this.showImageDialog = true
      },
      onPictureInsertDialogClosed(imgUrl) {
        if (imgUrl != null && imgUrl !== "") {
          this.insertFuckingImage(imgUrl);
        }
        this.showImageDialog = false
      },
      insertFuckingImage(imgUrl) {
        const containerNode = document.querySelector('.news-content');
        const node = document.createElement("img");
        node.src = imgUrl;
        let sel, range, html, str;

        function isOrContainsNode(ancestor, descendant) {
          var node = descendant;
          while (node) {
            if (node === ancestor) {
              return true;
            }
            node = node.parentNode;
          }
          return false;
        }

        if (window.getSelection) {
          sel = window.getSelection();
          if (sel.getRangeAt && sel.rangeCount) {
            range = sel.getRangeAt(0);
            if (isOrContainsNode(containerNode, range.commonAncestorContainer)) {
              range.deleteContents();
              range.insertNode(node);
            } else {
              containerNode.appendChild(node);
            }
          }
        } else if (document.selection && document.selection.createRange) {
          range = document.selection.createRange();
          if (isOrContainsNode(containerNode, range.parentElement())) {
            html = (node.nodeType === 3) ? node.data : node.outerHTML;
            range.pasteHTML(html);
          } else {
            containerNode.appendChild(node);
          }
        }
      },
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
          const response = await fetch(`${API_HOST}:${API_PORT}/news/UploadImage`, {
            method: 'POST',
            body: formData
          });
          const fileSrc = await response.text();
          console.log(fileSrc);
          this.editingNews.image = `${API_HOST}:${API_PORT}/${fileSrc.replace(/\\/g, '/')}`
        }
      },
      async save(event) {
        const body = {
          "NewsName": this.editingNews.title,
          "NewsShortText": this.editingNews.short,
          "NewsFullText": document.querySelector('.news-content').innerHTML,
          "NewsImage": this.editingNews.image
        };
        const response = await fetch(`${API_HOST}:${API_PORT}/news/addnews`, {
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

  .editor-toolbar {
    display: flex;
  }

  .news-content {
    margin-top: 20px;
  }

  .toolbar-button {
    box-sizing: border-box;
    width: 32px;
    height: 32px;
    padding: 8px;
    border-radius: 5px;
    cursor: pointer;

    svg {
      width: 16px;
    }

    &:active {
      border: 1px solid $primary-color;
    }
  }
</style>