<template>
  <v-card
    class="mx-auto"
    max-width="344"
    outlined
  >
    <v-list-item three-line>
      <v-avatar
        tile
        size="60"
      >
        <img
          alt="Avatar"
          src="@/assets/default_profile_picture.jpeg"
        >
      </v-avatar>
      <v-list-item-content>
        <v-list-item-title class="text-h5 mb-1">
          Bram Hurkmans
        </v-list-item-title>
        <v-list-item-subtitle>Greyhound divisely hello coldly fonwderfully</v-list-item-subtitle>
      </v-list-item-content>
    </v-list-item>
  </v-card>
</template>

<script>
  export default {
    name: 'KrabbelComponent',
    components: {
    },
  }
</script>
