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
      //config.headers.Authorization = `Bearer eyJhbGciOiJSUzI1NiIsInR5cCIgOiAiSldUIiwia2lkIiA6ICJKTks5cEk1aFdjRm5oVWVraFlPYi1hM0hxcWJPZHJ0SlVGeS1ZeGFMdmFvIn0.eyJleHAiOjE2NTU3MDM2ODksImlhdCI6MTY1NTY2ODMzNCwiYXV0aF90aW1lIjoxNjU1NjY3Njg5LCJqdGkiOiJhMzFhYjNhNy05NWVjLTQxZmMtYjhkZC0zZDVhNDg2NTU1Y2QiLCJpc3MiOiJodHRwczovL2tleWNsb2FrLmh5dmVzLnNvY2lhbC9hdXRoL3JlYWxtcy9IeXZlczIiLCJhdWQiOlsidXNlciIsImFjY291bnQiXSwic3ViIjoiZDMxZDQ0MWQtNDM0Mi00ZjkzLTk0MWUtNGIyYzA4ZDUzMGZlIiwidHlwIjoiQmVhcmVyIiwiYXpwIjoidXNlciIsInNlc3Npb25fc3RhdGUiOiJmMDdlNjM5ZS1hNjQzLTRkNzctYmE0My0wYTU4MDQ1YzcxYjUiLCJyZWFsbV9hY2Nlc3MiOnsicm9sZXMiOlsiZGVmYXVsdC1yb2xlcy1oeXZlczIiLCJvZmZsaW5lX2FjY2VzcyIsInVtYV9hdXRob3JpemF0aW9uIl19LCJyZXNvdXJjZV9hY2Nlc3MiOnsiYWNjb3VudCI6eyJyb2xlcyI6WyJtYW5hZ2UtYWNjb3VudCIsIm1hbmFnZS1hY2NvdW50LWxpbmtzIiwidmlldy1wcm9maWxlIl19fSwic2NvcGUiOiJvcGVuaWQgcHJvZmlsZSBlbWFpbCIsInNpZCI6ImYwN2U2MzllLWE2NDMtNGQ3Ny1iYTQzLTBhNTgwNDVjNzFiNSIsImVtYWlsX3ZlcmlmaWVkIjpmYWxzZSwibmFtZSI6ImNjYyBjY2MiLCJncm91cHMiOltdLCJwcmVmZXJyZWRfdXNlcm5hbWUiOiJjY2MiLCJnaXZlbl9uYW1lIjoiY2NjIiwiZmFtaWx5X25hbWUiOiJjY2MiLCJlbWFpbCI6ImNjY0BjY2MubmwifQ.Yk25ntKZxo0UOxXQ1TN90OCm3GMx1BhraKW1C9hprhdnDodRr2mAryVQ5C_NThNawFdFqQpRutGOZgDOln89rcr2Zd5hW59x2XwcR3EhZpWpmj1y9byBEHTPHiGjpkN0vwFT4HAU-DhQMDifLebiruJVeFviuXeTHomtEPIK4Qx5L3W6ybFC3vtaryTdq7bRJUZKM-Zrtg35dR4MII2Ef8HZsHMBxf1V5NXV5W-ghYtjYaMTGeeAY_kgeEvMmqTZW9N8EtLALch3tPyNbUSIyX27Eq_P1hh-klRIj4Uw3mIYWM8gVirRWOq_LtvDhAiKiQGpEM2vXxpMDcKYKVUybA`
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
