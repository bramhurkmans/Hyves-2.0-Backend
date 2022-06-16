<template>
  <v-app>
    <v-app-bar
      app
      color="secondary"
      elevation="20"
      extension-height="32"
    >
      <div class="d-flex align-center">
        <v-img
          alt="Hyves Logo"
          class="shrink mr-2"
          contain
          src="@/assets/logo.png"
          transition="scale-transition"
          width="auto"
        />
      </div>

      <v-spacer></v-spacer>

      <div class="d-flex align-center">
        <v-img
        max-height="3em"
          alt="Profielfoto"
          class="shrink mr-2"
          contain
          src="@/assets/default_profile_picture.jpeg"
          width="auto"
        />
      </div>

      <template #extension>
        <v-toolbar dark color="accent" height="32">
          <v-btn
            href=""
            text
            to="/"
          >
            <span class="mr-2">Home</span>
          </v-btn>
                    
          <v-btn
            href=""
            text
            to="/profile"
          >
            <span class="mr-2">Vrienden</span>
          </v-btn>

          <v-btn
            href=""
            target="_blank"
            text
          >
            <span class="mr-2">Hyves</span>
          </v-btn>

          <v-btn
            href=""
            target="_blank"
            text
          >
            <span class="mr-2">Eindhoven</span>
          </v-btn>

          <v-btn
            href=""
            target="_blank"
            text
          >
            <span class="mr-2">Scholen</span>
          </v-btn>

          <v-btn
            href=""
            target="_blank"
            text
          >
            <span class="mr-2">Foto's</span>
          </v-btn>

          <v-btn
            href=""
            target="_blank"
            text
          >
            <span class="mr-2">Video's</span>
          </v-btn>

          <v-btn
            href=""
            target="_blank"
            text
          >
            <span class="mr-2">Muziek</span>
          </v-btn>

          <v-btn
            href=""
            target="_blank"
            text
          >
            <span class="mr-2">Blogs</span>
          </v-btn>
        </v-toolbar>
      </template>
    </v-app-bar>

    <v-main>
      <router-view/>
    </v-main>
  </v-app>
</template>

<script>
import axios from 'axios'
import JwtService from "./common/jwt.service"

export default {
  name: 'App',

  data: () => ({
    //
  }),
  created: function () {
    // Set the auth token for any request
    axios.interceptors.request.use(config => {
      config.headers.Authorization = `Bearer ${JwtService.getToken()}`;
      //config.baseURL = "http://127.0.0.1:8000"
      config.baseURL = "https://staging.hyves.social"
      return config;
    });

    // Last step: handle request error general case
    axios.interceptors.response.use(
      response => response,
      error => {
        // Error
        const { response: { status } } = error;

        if (status === 401) {
          JwtService.destroyToken()
          this.$router.push('/login')
        }
      }
    );
  },
};
</script>

<style scoped>
.v-toolbar__content, .v-toolbar__extension {
  padding: 0 !important;
}
</style>
