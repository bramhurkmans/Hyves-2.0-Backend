import axios from 'axios'
import { CREATE_HOBBY, CREATE_SONG, DELETE_HOBBY, DELETE_SONG, GET_HOBBIES, GET_SONGS } from "./actions.type";
import {
  SET_HOBBIES,
  SET_SONGS,
} from "./mutations.type";


const state = {
  songs: [],
  hobbies: []
};

const getters = {
  getHobbies: state => state.songs,
  getSongs: state => state.hobbies,
};

const actions = {
  async [GET_HOBBIES](context, userId) {
    return new Promise((resolve, reject) => {        
        axios({url: `/api/profiles/${userId}/hobbies`, data: null, method: 'GET' })
        .then(resp => {
            context.commit(SET_HOBBIES, resp)
            resolve(resp)
        })
        .catch(err => {
            reject(err)
        })
    })
  },
  async [CREATE_HOBBY](hobby) {
    return new Promise((resolve, reject) => {        
        axios({url: `/api/profiles/0/hobbies`, data: hobby, method: 'POST' })
        .then({
        })
        .catch(err => {
            reject(err)
        })
    })
  },
  async [DELETE_HOBBY](hobbyId) {
    return new Promise((resolve, reject) => {        
        axios({url: `/api/profiles/0/hobbies/${hobbyId}`, data: null, method: 'DELETE' })
        .then({
        })
        .catch(err => {
            reject(err)
        })
    })
  },
  async [GET_SONGS](context, userId) {
    return new Promise((resolve, reject) => {        
        axios({url: `/api/profiles/${userId}/songs`, data: null, method: 'GET' })
        .then(resp => {
            context.commit(SET_SONGS, resp)
            resolve(resp)
        })
        .catch(err => {
            reject(err)
        })
    })
  },
  async [CREATE_SONG](song) {
    return new Promise((resolve, reject) => {        
        axios({url: `/api/profiles/0/songs`, data: song, method: 'POST' })
        .then({
        })
        .catch(err => {
            reject(err)
        })
    })
  },
  async [DELETE_SONG](songId) {
    return new Promise((resolve, reject) => {        
        axios({url: `/api/profiles/0/songs/${songId}`, data: null, method: 'DELETE' })
        .then({
        })
        .catch(err => {
            reject(err)
        })
    })
  }
};

const mutations = {
  [SET_HOBBIES](state, data) {
    state.hobbies = data;
  },
  [SET_SONGS](state, data) {
    state.songs = data;
  },
};

export default {
  state,
  actions,
  mutations,
  getters
};
