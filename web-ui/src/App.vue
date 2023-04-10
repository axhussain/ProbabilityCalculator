<template>
  <div id="app">
    <main class="container">
      <div class="px-4 py-5 my-1 text-center">
        <h1 class="display-5 fw-bold">Probability Calculator</h1>
        <div class="col-lg-6 mx-auto">
          <p class="lead mb-4">
            Enter probabilities to carry out basic calculations.
          </p>
        </div>
      </div>

      <div class="row">
        <div class="col-md-3">
          <label for="pA" class="form-label">P(A)</label>
          <ValidationProvider rules="required|between:0,1" v-slot="{ errors }">
            <input type="text" class="form-control" id="pA" v-model="pA" />
            <span>{{ errors[0] }}</span>
          </ValidationProvider>
        </div>

        <div class="col-md-3">
          <label for="pB" class="form-label">P(B)</label>
          <ValidationProvider rules="required|between:0,1" v-slot="{ errors }">
            <input type="text" class="form-control" id="pB" v-model="pB" />
            <span>{{ errors[0] }}</span>
          </ValidationProvider>
        </div>

        <div class="col-md-5">
          <label class="form-label mx-3">Select a calculation</label><br />
          <button @click="combinedWith" class="btn btn-primary btn-md mx-3">
            Combined with
          </button>
          <button @click="either" class="btn btn-primary btn-md">Either</button>
        </div>
      </div>

      <div class="row my-3" v-if="result">
        <div class="col-md-1">Output:</div>
        <div class="col-md-1">
          {{ result }}
        </div>
      </div>
    </main>
  </div>
</template>

<script lang="ts">
  import { Component, Vue } from "vue-property-decorator";
  import { ValidationProvider, extend } from "vee-validate";
  import { required, between } from "vee-validate/dist/rules";
  import axios from "axios";

  extend("required", {
    ...required,
    message: "This is a required field",
  });

  extend("between", {
    ...between,
    message: "Probability must be between 0 and 1",
  });

  @Component({
    components: {
      ValidationProvider,
    },
  })
  export default class App extends Vue {
    pA: number | null = null;
    pB: number | null = null;
    result: number | null = null;

    public combinedWith(): void {
      axios
        .get("http://localhost:5000/api/Probabilities/CombinedWith", {
          params: {
            pA: this.pA,
            pB: this.pB,
          },
        })
        .then((response) => {
          this.result = response.data;
        })
        .catch((error) => {
          console.error(error);
        });
    }

    public either(): void {
      axios
        .get("http://localhost:5000/api/Probabilities/Either", {
          params: {
            pA: this.pA,
            pB: this.pB,
          },
        })
        .then((response) => {
          this.result = response.data;
        })
        .catch((error) => {
          console.error(error);
        });
    }
  }
</script>

<style>
</style>
