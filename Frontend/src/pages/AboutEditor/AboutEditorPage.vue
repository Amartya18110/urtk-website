<template>
  <div class="root">
    <div class="title-wrapper">
      <h1 class="title">О проекте</h1>
      <ActionButton @click="save" class="save-button">Сохранить</ActionButton>
    </div>
    <RichTextEditor class="content-editor" @input="updateText"></RichTextEditor>
  </div>
</template>

<script>
  import ActionButton from "../../components/ActionButton/ActionButton.vue";
  import RichTextEditor from "../../components/RichTextEditor/RichTextEditor.vue";
  export default {
    name: "AboutEditorPage",
    components: {RichTextEditor, ActionButton},
    created() {
      this.loadAboutText();
    },
    data() {
      return {
        text: ""
      }
    },
    methods: {
      updateText(text) {
        this.text = text
      },
      async loadAboutText() {
        const response = await fetch(API_ADDRESS + 'about/get');
        if (response.status === 200) {
          const about = await response.json();
          document.querySelector('.content-editor .content').innerHTML = about.aboutFullText;
        }
      },
      async save() {
        const body = {
          "AboutFullText": this.text
        };
        const response = await fetch(API_ADDRESS + 'about/update', {
          method: 'POST',
          headers: {
            'content-type': 'application/json'
          },
          body: JSON.stringify(body)
        });
        this.$router.push('/about');
      }
    }
  }
</script>

<style scoped>
  .root {
    padding: 0 20vw;
  }

  .title-wrapper {
    margin-top: 20px;
    display: flex;
    align-items: center;
  }

  .save-button {
    margin-left: 50px;
  }
</style>