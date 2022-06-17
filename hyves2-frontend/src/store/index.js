import Vue from 'vue'
import Vuex from 'vuex'
import oauth from './oauth.module'
import users from './users.module'
import profiles from './profiles.module'
import krabbels from './krabbels.module'


Vue.use(Vuex)

export default new Vuex.Store({
  modules: {
    oauth,
    users,
    profiles,
    krabbels
  },
  // enable strict mode (adds overhead!)
  // for dev mode only
  strict: process.env.DEV
})
