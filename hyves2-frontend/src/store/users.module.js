import axios from 'axios'
import { GET_USER_BY_ID, SEARCH_USERS } from "./actions.type";
import {
  SET_FRIENDS,
  SET_USER_BY_ID,
  SET_USER_SEARCH,
} from "./mutations.type";


const state = {
  friends: [],
  usersSearch: [],
  userById: {}
};

const getters = {
  getFriends: state => state.friends,
  getUsersSearch: state => state.usersSearch,
  getUserById: state => state.userById
};

const actions = {
  async [GET_USER_BY_ID](context, { userId }) {
    return new Promise((resolve, reject) => {        
        axios({url: `/api/users/${userId}`, data: null, method: 'GET' })
        .then(resp => {
            context.commit(SET_USER_BY_ID, resp)
            resolve(resp)
        })
        .catch(err => {
            reject(err)
        })
    })
  },
  async [SEARCH_USERS](context, { query }) {
    return new Promise((resolve, reject) => {        
        axios({url: `/api/users/search/${query}`, data: null, method: 'GET' })
        .then(resp => {
          console.log("dta:"+ resp.data)
          context.commit(SET_USER_SEARCH, resp.data)
          resolve(resp)
        })
        .catch(err => {
            reject(err)
        })
    })
  }
};

const mutations = {

  [SET_FRIENDS](state, data) {
    state.friends = data;
  },
  [SET_USER_SEARCH](state, data) {
    state.usersSearch = data;
  },
  [SET_USER_BY_ID](state, data) {
    state.userById = data;
  }
};

export default {
  state,
  actions,
  mutations,
  getters
};
