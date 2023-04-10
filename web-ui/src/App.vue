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
          <button class="btn btn-primary btn-md mx-3">Combined with</button>
          <button class="btn btn-primary btn-md">Either</button>
        </div>
      </div>
    </main>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { ValidationProvider, extend } from "vee-validate";
import { required, between } from "vee-validate/dist/rules";

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
}
</script>

<style>
</style>
