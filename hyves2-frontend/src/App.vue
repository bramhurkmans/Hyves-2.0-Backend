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
      config.headers.Authorization = `Bearer eyJhbGciOiJSUzI1NiIsInR5cCIgOiAiSldUIiwia2lkIiA6ICJKTks5cEk1aFdjRm5oVWVraFlPYi1hM0hxcWJPZHJ0SlVGeS1ZeGFMdmFvIn0.eyJleHAiOjE2NTU2MTk4NjcsImlhdCI6MTY1NTU4Mzg2NywiYXV0aF90aW1lIjoxNjU1NTgzODY3LCJqdGkiOiI5N2EzMTYwMi0zZWQ5LTRkMTktYWZjMy0zZjgwNDRhMWQ2MWEiLCJpc3MiOiJodHRwczovL2tleWNsb2FrLmh5dmVzLnNvY2lhbC9hdXRoL3JlYWxtcy9IeXZlczIiLCJhdWQiOlsidXNlciIsImFjY291bnQiXSwic3ViIjoiMGUwMzViNjEtOTRjOS00YTllLWI3MTgtYTAyYTg3NzkzNTFjIiwidHlwIjoiQmVhcmVyIiwiYXpwIjoidXNlciIsInNlc3Npb25fc3RhdGUiOiJiNWViYTQ2Ny03NmZmLTQ2MWItYThkYS1hMTkwNjc4OTFiMDgiLCJyZWFsbV9hY2Nlc3MiOnsicm9sZXMiOlsiZGVmYXVsdC1yb2xlcy1oeXZlczIiLCJvZmZsaW5lX2FjY2VzcyIsInVtYV9hdXRob3JpemF0aW9uIl19LCJyZXNvdXJjZV9hY2Nlc3MiOnsiYWNjb3VudCI6eyJyb2xlcyI6WyJtYW5hZ2UtYWNjb3VudCIsIm1hbmFnZS1hY2NvdW50LWxpbmtzIiwidmlldy1wcm9maWxlIl19fSwic2NvcGUiOiJwcm9maWxlIGVtYWlsIiwic2lkIjoiYjVlYmE0NjctNzZmZi00NjFiLWE4ZGEtYTE5MDY3ODkxYjA4IiwiZW1haWxfdmVyaWZpZWQiOmZhbHNlLCJuYW1lIjoic3NzIHNzcyIsImdyb3VwcyI6W10sInByZWZlcnJlZF91c2VybmFtZSI6InNzcyIsImdpdmVuX25hbWUiOiJzc3MiLCJmYW1pbHlfbmFtZSI6InNzcyIsImVtYWlsIjoic3NzQHNzcy5ubCJ9.p_7LrtvatqUnx0qi0iHC7Yn2T6oT6AgjP-WPT_G8iTMs-LMzMGORXQyprhxmsxaKxp_nRgDpXJdgYbVDr0DF6kJfiy3NdocSc6Ot-14cPgN2Pfv8iHFjgwljwzI5qvv7fSXEluHZrxwwdQJhBsZ6klynq6wXAbgLtJQFlsTGeL9JpJRKk1ghMc1FsHiYF-EfiuqS0A2o4WmwoRRYwRaVU2uUON-qTul3N5tS5bIJZbNSQd_qCcsbHYIiOPWgBuFGbaLYYnBEGuMUV8kgHcfpBJd-5vzF6QXY8PlG554jn-Zv0o5rsL9siQkod13fo5kLnYN4MO_DU8FWICCIxLfATg`
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
