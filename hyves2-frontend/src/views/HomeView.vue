<template>
  <v-container>
    <div class="search">
      <h1>Zoek naar personen</h1>
      <v-autocomplete
        v-model="chosenUser"
        :items="users"
        :search-input.sync="search"
        color="white"
        hide-no-data
        hide-selected
        item-text="firstName"
        item-value="API"
        label="Vul een naam in"
        placeholder="Vul een naam in"
        prepend-icon="mdi-database-search"
        return-object
      ></v-autocomplete>
    </div>
  </v-container>
</template>

<script>
import { GET_ME, SEARCH_USERS } from '@/store/actions.type'

  export default {
    name: 'HomeView',

    data: () => ({
      chosenUser: {},
      queryTerm: ''
    }),
    computed: {
      search: {
        get () {
          return this.queryTerm
        },
        
        set (searchInput) {
          if (this.queryTerm !== searchInput) {
            this.queryTerm = searchInput
            this.loadEntries()
          }
        }
      },
      users() {
        return this.$store.getters.getUsersSearch
      }
    },
    created () {
      this.loadEntries()
      this.$store.dispatch(GET_ME);
    },

    methods: {
      async loadEntries () {
        this.$store.dispatch(SEARCH_USERS, {query: this.queryTerm });
      }
    },
    watch: {
      chosenUser: {
        deep: true,
        handler (newValue) {
          if(Number.isInteger(newValue.id)) {
            this.$router.push(`/profile/${newValue.id}`)
          }
        }
      }
    }
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