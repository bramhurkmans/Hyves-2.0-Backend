import Vue from 'vue'
import Vuex from 'vuex'
import oauth from './oauth.module'

Vue.use(Vuex)

export default new Vuex.Store({
  modules: {
    oauth
  },
  // enable strict mode (adds overhead!)
  // for dev mode only
  strict: process.env.DEV
})
