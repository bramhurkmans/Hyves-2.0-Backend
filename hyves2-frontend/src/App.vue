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
      config.headers.Authorization = `Bearer eyJhbGciOiJSUzI1NiIsInR5cCIgOiAiSldUIiwia2lkIiA6ICJKTks5cEk1aFdjRm5oVWVraFlPYi1hM0hxcWJPZHJ0SlVGeS1ZeGFMdmFvIn0.eyJleHAiOjE2NTU2MjQ5MDAsImlhdCI6MTY1NTU4ODkwMCwiYXV0aF90aW1lIjoxNjU1NTg4OTAwLCJqdGkiOiJiNGQ2OTc1Mi0wNmI4LTQzZmYtOTljYi02NzRiNWMzM2M1NjEiLCJpc3MiOiJodHRwczovL2tleWNsb2FrLmh5dmVzLnNvY2lhbC9hdXRoL3JlYWxtcy9IeXZlczIiLCJhdWQiOlsidXNlciIsImFjY291bnQiXSwic3ViIjoiZDFhODgyYTItZTYyOC00NzlmLWI2ZDQtNGUyNGJkNTg1NTA3IiwidHlwIjoiQmVhcmVyIiwiYXpwIjoidXNlciIsInNlc3Npb25fc3RhdGUiOiJmZDU5MGE4Ni0xNTZlLTRhNjMtYmUwYS05MjYwYjIzZTVmYzQiLCJyZWFsbV9hY2Nlc3MiOnsicm9sZXMiOlsiZGVmYXVsdC1yb2xlcy1oeXZlczIiLCJvZmZsaW5lX2FjY2VzcyIsInVtYV9hdXRob3JpemF0aW9uIl19LCJyZXNvdXJjZV9hY2Nlc3MiOnsiYWNjb3VudCI6eyJyb2xlcyI6WyJtYW5hZ2UtYWNjb3VudCIsIm1hbmFnZS1hY2NvdW50LWxpbmtzIiwidmlldy1wcm9maWxlIl19fSwic2NvcGUiOiJwcm9maWxlIGVtYWlsIiwic2lkIjoiZmQ1OTBhODYtMTU2ZS00YTYzLWJlMGEtOTI2MGIyM2U1ZmM0IiwiZW1haWxfdmVyaWZpZWQiOmZhbHNlLCJuYW1lIjoiZGRkIGRkZCIsImdyb3VwcyI6W10sInByZWZlcnJlZF91c2VybmFtZSI6ImRkZCIsImdpdmVuX25hbWUiOiJkZGQiLCJmYW1pbHlfbmFtZSI6ImRkZCIsImVtYWlsIjoiZGRkQGRkZC5ubCJ9.hd5HPwYS27QbHvClQYcZzJPtxmj5uxUoz1BmyUXglsQNwIVm8Wx-LA3-G7YJKOIN1bdimnM7OtxQGhOl4FL7ggqMEwymY5dZTk6ifN10Lc8UjX-S-p2PJQ71Pm652ODPnzBHJOYlyafhZG5fqtJowW8HKSs4NMxZeSaiB9YDTpil6AAvi7HwV8GCraC4jT_zKfvwmASrkzG8sodicbf9bVG8WzRI6qs0lscW-CwDzzWfIQsYqkAPxUPdMUEvYH0yFNYC7StfE6abpBzgEiaAHSXhvown0axjHvqskTBwhhWBMATvtHq85EqPp95-YCnP2NNfZrQKoImtbsgly8xA5g`
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
