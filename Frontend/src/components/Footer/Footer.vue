<template>
    <footer>
        <router-link to="login">вход для администратора</router-link>
    </footer>
</template>

<script>
    export default {
        name: "Footer"
    }
</script>

<style scoped>
    footer {
        padding: 20px 20px;
    }

    a {
        display: inline-block;
        border-bottom: 1px solid #aaa;
        color: #aaa;
    }
</style>