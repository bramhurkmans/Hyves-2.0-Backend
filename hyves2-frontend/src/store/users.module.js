import axios from 'axios'
import { GET_USER_BY_ID, SEARCH_USERS } from "./actions.type";
import {
  SET_FRIENDS,
  SET_USER_BY_ID,
} from "./mutations.type";


const state = {
  friends: [],
  usersSearch: []
};

const getters = {
  getFriends: state => state.friends,
  getUsersSearch: state => state.usersSearch,
};

const actions = {
  async [GET_USER_BY_ID](context, userId) {
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
  async [SEARCH_USERS](query) {
    return new Promise((resolve, reject) => {        
        axios({url: `/api/users/search/${query}`, data: null, method: 'POST' })
        .then({
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
  }
};

export default {
  state,
  actions,
  mutations,
  getters
};
