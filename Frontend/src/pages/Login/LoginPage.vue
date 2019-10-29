<template>
  <div class="login-page">
    <form class="login-form" @submit.prevent.stop>
      <h1>Вход</h1>
      <div class="field-group">
        <label for="login-field">Логин:</label>
        <input id="login-field" type="text" v-model="login" @input="hideError">
      </div>
      <div class="field-group">
        <label for="pass-field">Пароль:</label>
        <input id="pass-field" type="password" v-model="password" @input="hideError">
      </div>
      <div class="error-message">{{errorMessage}}</div>
      <button class="sign-in-button" @click="signIn">Войти</button>
    </form>
  </div>
</template>

<script>
  export default {
    name: "LoginPage",
    data() {
      return {
        login: "",
        password: "",
        errorMessage: ""
      }
    },
    methods: {
      hideError() {
        this.errorMessage = "";
      },
      signIn() {
        this.errorMessage = "";
        fetch(`${API_HOST}:${API_PORT}/auth`, {
          method: 'POST',
          headers: {
            'content-type': 'application/json'
          },
          body: JSON.stringify({ UserLogin: this.login, UserPass: this.password })
        })
        .then(response => {
          if (response.status === 200) {
            return response.json();
          } else {
            response.reject();
          }
        })
        .then(json => {
          localStorage.setItem('signed_as', json.userName);
          this.$router.push('/');
        })
        .catch(() => this.errorMessage = "неверный логин или пароль");
      }
    }
  }
</script>

<style scoped lang="scss">
  .login-form {
    width: 300px;
    margin: 120px auto 0 auto;
    padding: 20px;
    border: 1px solid #aaa;
    border-radius: 10px;
  }

  .sign-in-button {
    margin-top: 20px;
    font-size: 16px;
    padding: 5px;
  }

  .field-group {
    margin: 10px 0;
    display: flex;
    justify-content: space-between;
    align-items: center;

    input {
      padding: 6px;
    }
  }

  .error-message {
    color: red;
  }
</style>