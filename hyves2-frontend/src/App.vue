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
//mport JwtService from "./common/jwt.service"

export default {
  name: 'App',

  data: () => ({
    //
  }),
  created: function () {
    // Set the auth token for any request
    axios.interceptors.request.use(config => {
      //config.headers.Authorization = `Bearer ${JwtService.getToken()}`;
      config.headers.Authorization = `Bearer eyJhbGciOiJSUzI1NiIsInR5cCIgOiAiSldUIiwia2lkIiA6ICJKTks5cEk1aFdjRm5oVWVraFlPYi1hM0hxcWJPZHJ0SlVGeS1ZeGFMdmFvIn0.eyJleHAiOjE2NTU0NjM1NzcsImlhdCI6MTY1NTQyNzU3NywiYXV0aF90aW1lIjoxNjU1NDI3NTc3LCJqdGkiOiIyYmY1YTI5NS04ODM2LTQ4ZjctOWU3Yi00NGNkZWZhNDhmMDUiLCJpc3MiOiJodHRwczovL2tleWNsb2FrLmh5dmVzLnNvY2lhbC9hdXRoL3JlYWxtcy9IeXZlczIiLCJhdWQiOlsidXNlciIsImFjY291bnQiXSwic3ViIjoiMGUwMzViNjEtOTRjOS00YTllLWI3MTgtYTAyYTg3NzkzNTFjIiwidHlwIjoiQmVhcmVyIiwiYXpwIjoidXNlciIsInNlc3Npb25fc3RhdGUiOiJhODRkNzI4YS02OWQyLTQ5NzQtODkwYS1hYmQ5ZDFkNDY2YjMiLCJyZWFsbV9hY2Nlc3MiOnsicm9sZXMiOlsiZGVmYXVsdC1yb2xlcy1oeXZlczIiLCJvZmZsaW5lX2FjY2VzcyIsInVtYV9hdXRob3JpemF0aW9uIl19LCJyZXNvdXJjZV9hY2Nlc3MiOnsiYWNjb3VudCI6eyJyb2xlcyI6WyJtYW5hZ2UtYWNjb3VudCIsIm1hbmFnZS1hY2NvdW50LWxpbmtzIiwidmlldy1wcm9maWxlIl19fSwic2NvcGUiOiJwcm9maWxlIGVtYWlsIiwic2lkIjoiYTg0ZDcyOGEtNjlkMi00OTc0LTg5MGEtYWJkOWQxZDQ2NmIzIiwiZW1haWxfdmVyaWZpZWQiOmZhbHNlLCJuYW1lIjoic3NzIHNzcyIsImdyb3VwcyI6W10sInByZWZlcnJlZF91c2VybmFtZSI6InNzcyIsImdpdmVuX25hbWUiOiJzc3MiLCJmYW1pbHlfbmFtZSI6InNzcyIsImVtYWlsIjoic3NzQHNzcy5ubCJ9.S-WD6gyvAiHEZROknGpoKYA3vf5DkVPpxMt9qAALlnSg4nk1XPVzwrYDkqH9k4xgWWS7pCfpKUiIQQgZ_L6b9Q3d_6my9P5CLYdD5zG87X3rupMc3CiU2z4Q39mLOb--aGYxH3Qu7AM70xHwTnytqwM7zkYNo_bLSmuVcjsWZc3Uu_oQOLS3JUcQnVBleljTHeNZKoetZO33F-VBSdlUXwh-IP_mCVtcv84T5WseOQAIvCZy5bpspYLnzO2Xtrtp4PlLS-9IXk1_VAbxiE-DlWqZzNAFiuC5MbMkD-9X5EmjN05r2NPfIbIJcP9PrJLXvY82WPbgB2XfbGs1P6V-Zw`
      //config.baseURL = "http://127.0.Bearer0.1:8000"
      config.baseURL = "https://staging.hyves.social"
      return config;
    });

    // Last step: handle request error general case
    // axios.interceptors.response.use(
    //   response => response,
    //   error => {
    //     // Error
    //     const { response: { status } } = error;

    //     if (status === 401) {
    //       JwtService.destroyToken()
    //       this.$router.push('/login')
    //     }
    //   }
    // );
  },
};
</script>

<style scoped>
.v-toolbar__content, .v-toolbar__extension {
  padding: 0 !important;
}
</style>
