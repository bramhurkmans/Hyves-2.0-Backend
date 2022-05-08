<template>
  <v-container>
    <h2>Vrienden (666)</h2>

    <v-row>
      <v-col>
        <friend-icon></friend-icon>
      </v-col>
      <v-col>
        <friend-icon></friend-icon>
      </v-col>
      <v-col>
        <friend-icon></friend-icon>
      </v-col>
    </v-row>
        <v-row>
      <v-col>
        <friend-icon></friend-icon>
      </v-col>
      <v-col>
        <friend-icon></friend-icon>
      </v-col>
      <v-col>
        <friend-icon></friend-icon>
      </v-col>
    </v-row>
        <v-row>
      <v-col>
        <friend-icon></friend-icon>
      </v-col>
      <v-col>
        <friend-icon></friend-icon>
      </v-col>
      <v-col>
        <friend-icon></friend-icon>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import FriendIcon from './friends/FriendIcon.vue'
  export default {
    name: 'FriendsComponent',
    components: {
      FriendIcon
    },
  }
</script>
