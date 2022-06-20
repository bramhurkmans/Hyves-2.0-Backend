<template>
  <v-container class="hyvesPrimary">
    <h1>{{ user.firstName }} {{ user.lastName }}</h1>
    <change-theme-modal></change-theme-modal>

    <v-row>
      <v-col cols="3">
        <v-card
          class="pa-2"
          outlined
          tile
        >
          <user-component></user-component>
        </v-card>
      </v-col>
      <v-col cols="4">
        <v-card
          class="pa-2"
          outlined
          tile
        >
          <profile-component></profile-component>
        </v-card>
      </v-col>
      <v-col cols="5">
        <v-card
          class="pa-2"
          outlined
          tile
        >
          <friends-component></friends-component>
        </v-card>
      </v-col>
    </v-row>
    <v-row>
      <v-col cols="3">
        <v-card
          class="pa-2"
          outlined
          tile
        >
          <krabbel-section-component></krabbel-section-component>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import KrabbelSectionComponent from '@/components/krabbels/KrabbelSectionComponent.vue'
import FriendsComponent from '../components/profile/FriendsComponent.vue'
import ProfileComponent from '../components/profile/ProfileComponent.vue'
import UserComponent from '../components/profile/UserComponent.vue'
import ChangeThemeModal from '../components/theme/ChangeThemeModal.vue'
import { GET_THEME, GET_USER_BY_ID } from '@/store/actions.type'

  export default {
    name: 'HomeProfile',

    components: {
      FriendsComponent,
        UserComponent,
        ProfileComponent,
        KrabbelSectionComponent,
        ChangeThemeModal
    },
    data() {
    return {}
    },
    created: function () {
      this.$store.dispatch(GET_USER_BY_ID, {userId: this.$route.params.id})
      this.$store.dispatch(GET_THEME, {userId: this.$route.params.id})
    },
    mounted: function () {
      
    },
    computed: {
      user() {
        return this.$store.getters.getUserById;
      },
      theme() {
        return this.$store.getters.getTheme;
      },
    },
    watch: {
      theme: {
        deep: true,
        handler (newValue) {
          console.log("got theme!")
          document.querySelectorAll(".hyvesPrimary").forEach(elem => elem.style.backgroundColor = newValue.primaryColor);

          document.querySelectorAll(".hyvesSecondary").forEach(elem => elem.style.backgroundColor = newValue.secondaryColor);

          document.querySelectorAll("h1, h2, h3, h4, h5, h6, span, p, li, a").forEach(elem => elem.style.color = newValue.textColor);
        }
      }
    }
  }
</script>

<style scoped>
  /* .test {
    color: red;
    background-color: red;
  } */
</style>