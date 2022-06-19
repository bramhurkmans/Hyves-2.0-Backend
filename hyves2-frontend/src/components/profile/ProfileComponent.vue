<template>
  <v-container class="hyvesSecondary">
    <h2>Profiel</h2>
    <p>666 x bekeken, Hyver sinds: 05-08-2006</p>

    <ul style="list-style-type:none;">
      <li><b>Naam: </b>{{ user.firstName }} {{ user.lastName }}</li>
      <!-- <li><b>Leeftijd: </b>23</li>
      <li><b>Woonplaats: </b>Valkenswaard</li>
      <li><b>School: </b>Fontys Hogescholen</li>
      <li><b>Studie: </b>ICT & Software</li> -->
      <li><b>Hobbies: </b> {{ hobbies }}</li>
      <li><b>Muziek: </b> {{ songs }}</li>
    </ul>  
  </v-container>
</template>

<script>
import { GET_HOBBIES, GET_SONGS, GET_USER_BY_ID } from '@/store/actions.type'
  export default {
    name: 'ProfileComponent',

    data() {
    return {}
    },
    created: function () {
      this.$store.dispatch(GET_USER_BY_ID, {userId: this.$route.params.id})
      this.$store.dispatch(GET_HOBBIES, {userId: this.$route.params.id})
      this.$store.dispatch(GET_SONGS, {userId: this.$route.params.id})
    },
    computed: {
      user() {
        return this.$store.getters.getUserById;
      },
      hobbies() {
        return this.$store.getters.getHobbies;
      },
      songs() {
        return this.$store.getters.getSongs;
      }
    }
  }
</script>
