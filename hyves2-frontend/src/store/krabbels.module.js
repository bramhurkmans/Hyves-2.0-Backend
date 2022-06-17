import axios from 'axios'
import { CREATE_KRABBEL, DELETE_KRABBEL, GET_KRABBELS_BY_USER } from "./actions.type";
import {
  SET_KRABBELS,
} from "./mutations.type";


const state = {
  krabbels: []
};

const getters = {
  getKrabbelsByUser: state => state.krabbels
};

const actions = {
  async [GET_KRABBELS_BY_USER](context, { userId }) {
    return new Promise((resolve, reject) => {        
        axios({url: `/api/krabbels/user/${userId}`, data: null, method: 'GET' })
        .then(resp => {
            context.commit(SET_KRABBELS, resp)
            resolve(resp)
        })
        .catch(err => {
            reject(err)
        })
    })
  },
  async [CREATE_KRABBEL](context, { userId, text }) {
    return new Promise((resolve, reject) => {        
        axios({url: `/api/krabbels/user/${userId}`, data: { Text: text }, method: 'POST' })
        .then({
        })
        .catch(err => {
            reject(err)
        })
    })
  },
  async [DELETE_KRABBEL](context, { krabbelId }) {
    return new Promise((resolve, reject) => {        
        axios({url: `/api/krabbels/${krabbelId}`, data: null, method: 'DELETE' })
        .then({
        })
        .catch(err => {
            reject(err)
        })
    })
  },
};

const mutations = {

  [SET_KRABBELS](state, data) {
    state.krabbels = data;
  }
};

export default {
  state,
  actions,
  mutations,
  getters
};
