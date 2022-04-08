<template>
  <div id="app">
    <!-- <nav>
      <router-link to="/">Home</router-link> |
      <router-link to="/about">About</router-link>
    </nav> -->
    <nav-bar/>
    <router-view/>
  </div>
</template>

<script>
import axios from 'axios'
import NavBar from '@/components/general/NavBar.vue'

export default {
  components: {
    NavBar
  },
    created: function () {
    // Set the auth token for any request
    axios.interceptors.request.use(config => {
      config.baseURL = "https://bram.dev"
      return config;
    });
  },
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

nav {
  padding: 30px;
}

nav a {
  font-weight: bold;
  color: #2c3e50;
}

nav a.router-link-exact-active {
  color: #42b983;
}
</style>
