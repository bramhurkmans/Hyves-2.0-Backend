<template>
  <v-container>
    <div class="search">
      <h1>Zoek naar personen</h1>
      <v-autocomplete
        v-model="newTag"
        :items="entries"
        :search-input.sync="search"
        color="white"
        hide-no-data
        hide-selected
        item-text="Description"
        item-value="API"
        label="Public APIs"
        placeholder="Vul een naam in"
        prepend-icon="mdi-database-search"
        return-object
      ></v-autocomplete>
    </div>
  </v-container>
</template>

<script>
import { SEARCH_USERS } from '@/store/actions.type'

  export default {
    name: 'HomeView',

    data: () => ({
      newTag: '',
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
      entries() {
        return this.$store.getters.getUsersSearch
      }
    },
    created () {
      this.loadEntries()
    },

    methods: {
      async loadEntries () {
        console.log("term:"+ this.queryTerm)
        this.$store.dispatch(SEARCH_USERS, this.queryTerm);
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