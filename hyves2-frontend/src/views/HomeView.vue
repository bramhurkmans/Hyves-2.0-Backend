<template>
  <v-container>
    <div class="search">
      <h1>Zoek naar personen</h1>
      <v-autocomplete
        v-model="values"
        :items="items"
        dense
        chips
        small-chips
        label="Vul een naam in"
        multiple
        solo
      ></v-autocomplete>
    </div>
  </v-container>
</template>

<script>

  export default {
    name: 'HomeView',

    components: {
    },
  }
</script>

<style scoped>
  .search {
    width: 500px;
    margin: auto;
    margin-top: 10%;
  }

  .search h1 {
    text-align: center;
  }
</style>