<template>
  <div class="editor-wrapper">
    <div class="editor-toolbar">
      <select @change="hSelected" v-model="selected">
        <option selected disabled value="">- форматирование -</option>
        <option value="h1">Заголовок 1</option>
        <option value="h2">Заголовок 2</option>
        <option value="h3">Заголовок 3</option>
        <option value="h4">Заголовок 4</option>
        <option value="h5">Заголовок 5</option>
        <option value="h6">Заголовок 6</option>
        <option value="p">Параграф</option>
      </select>
      <img class="toolbar-button button-bold" @click.prevent.stop="format('bold')" src="bold.svg" title="Жирный">
      <img class="toolbar-button button-bold" @click.prevent.stop="format('italic')" src="italic.svg" title="Курсив">
      <img class="toolbar-button button-bold" @click.prevent.stop="format('underline')" src="underline.svg" title="Подчеркнутый">
      <img class="toolbar-button button-bold" @click.prevent.stop="openPictureInsertDialog" src="pic.svg" title="Вставить изображение">
    </div>
    <SelectImageDialog @image-changed="onPictureInsertDialogClosed" v-show="showImageDialog"></SelectImageDialog>
    <div class="news-content" contenteditable="true" @input="$emit('input', $event.target.innerHTML)">
      Содержимое новости
    </div>
  </div>
</template>

<script>
  import SelectImageDialog from "../../components/SelectImageDialog/SelectImageDialog.vue";
  export default {
    name: "RichTextEditor",
    components: {SelectImageDialog},
    created() {
      document.execCommand("defaultParagraphSeparator", false, "p");
    },
    data() {
      return {
        selected: "",
        showImageDialog: false
      }
    },
    methods: {
      hSelected(event) {
        this.format('formatblock', this.selected);
        this.selected = "";
      },
      format(cmd, val) {
        document.execCommand(cmd, false, val);
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
      }
    }
  }
</script>

<style lang="scss" scoped>
  @import "common.scss";

  .editor-toolbar {
    display: flex;
    align-items: center;
    overflow: hidden;
  }

  .news-content {
    margin-top: 20px;
  }

  .toolbar-button {
    box-sizing: border-box;
    width: 16px;
    height: 16px;
    margin: 8px;
    border-radius: 5px;
    cursor: pointer;

    &:active {
      border: 1px solid $primary-color;
    }
  }

  select {
    padding: 8px 0;
  }

  p {
    margin-top: 15px;
  }
</style>