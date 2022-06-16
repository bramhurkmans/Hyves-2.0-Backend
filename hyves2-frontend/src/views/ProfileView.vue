<template>
  <v-container>
    <h1>Bram Hurkmans</h1>

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

  export default {
    name: 'HomeProfile',

    components: {
      FriendsComponent,
        UserComponent,
        ProfileComponent,
        KrabbelSectionComponent
    },
  }
</script>
