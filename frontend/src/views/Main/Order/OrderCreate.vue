<template>
  <showcase-create v-bind="createData">
    <showcase-label class="col-md-6" label="Клиент">
      <select class="form-select" v-model="dataToSend.client">
        <option disabled value="">
          Клиент
        </option>
        <option
          v-for="(item, index) in clientList"
          :key="index"
          :value="item.value"
        >
          {{ item.text }}
        </option>
      </select>
    </showcase-label>

    <showcase-label class="col-md-6" label="ТК">
      <select class="form-select" v-model="dataToSend.tc">
        <option disabled value="">
          ТК
        </option>
        <option
          v-for="(item, index) in tcList"
          :key="index"
          :value="item.value"
        >
          {{ item.text }}
        </option>
      </select>
    </showcase-label>

    <showcase-label class="col-md-6" label="Адрес">
      <input
        class="form-control"
        type="text"
        v-model="dataToSend.address"
        placeholder="Адрес"
      >
    </showcase-label>

    <showcase-label class="col-md-6" label="Номер ТТН">
      <input
        class="form-control"
        type="text"
        v-model="dataToSend.ttn"
        placeholder="Номер ТТН"
      >
    </showcase-label>

    <showcase-label class="col-md-6" label="Стоимость заказа">
      <input
        class="form-control"
        type="text"
        v-model="dataToSend.orderCost"
        placeholder="Стоимость"
      >
    </showcase-label>

    <showcase-label class="col-md-6" label="Номер платежного документа">
      <input
        class="form-control"
        type="text"
        v-model="dataToSend.paymentDoc"
        placeholder="Номер"
      >
    </showcase-label>

    <showcase-label class="col-md-4" label="Дата заказа">
      <input
        class="form-control"
        type="date"
        v-model="dataToSend.orderDate"
      >
    </showcase-label>

    <showcase-label class="col-md-4" label="Дата отгрузки">
      <input
        class="form-control"
        type="date"
        v-model="dataToSend.shippingDate"
      >
    </showcase-label>

    <showcase-label class="col-md-4" label="Дата доставки">
      <input
        class="form-control"
        type="date"
        v-model="dataToSend.deliveryDate"
      >
    </showcase-label>

    <showcase-label class="col-md-6" label="Статус">
      <select class="form-select" v-model="dataToSend.status">
        <option disabled value="">
          Статус
        </option>
        <option
          v-for="(item, index) in status"
          :key="index"
          :value="item.value"
        >
          {{ item.text }}
        </option>
      </select>
    </showcase-label>

    <showcase-label class="col-md-auto mt-auto" label="Принято ТК">
      <input
        class="form-check-input"
        type="checkbox"
        v-model="dataToSend.acceptTc"
      >
    </showcase-label>

    <showcase-label class="col-md-3 mt-auto" label="Принято клиентом">
      <input
        class="form-check-input"
        type="checkbox"
        v-model="dataToSend.acceptClient"
      >
    </showcase-label>

    <showcase-label class="col-md-12" label="Примечание">
      <textarea
        class="form-control"
        v-model="dataToSend.extra"
      ></textarea>
    </showcase-label>

    <showcase-label class="col-md-6" label="Артикул товара">
      <input
        class="form-control"
        type="text"
        v-model="dataToSend.art"
        placeholder="Стоимость"
      >
    </showcase-label>

    <showcase-label class="col-md-6" label="Кол-во">
      <input
        class="form-control"
        type="number"
        v-model="dataToSend.count"
      >
    </showcase-label>

    <showcase-submit>
      Добавить ещё один товар
    </showcase-submit>

    <showcase-errors-list
      v-if="v$.$errors.length"
      :errors="v$.$errors"
    />

    <showcase-submit @click="sendToServer">
      <edit-icon />
      Создать
    </showcase-submit>
  </showcase-create>
</template>

<script>
import { useVuelidate } from '@vuelidate/core'
import ShowcaseErrorsList from '@/components/Showcase/showcase-errors-list'
import ShowcaseCreate from '@/components/Showcase/showcase-create'
import ShowcaseLabel from '@/components/Showcase/showcase-label-field'
import ShowcaseSubmit from '@/components/Showcase/showcase-submit-button'
import { EditIcon } from '@iconicicons/vue3'
import {
  required
} from '@/utils/validation/i18n-validators'

export default {
  name: 'OrderCreate',
  components: {
    ShowcaseCreate,
    ShowcaseLabel,
    ShowcaseSubmit,
    ShowcaseErrorsList,
    EditIcon
  },
  setup () {
    return { v$: useVuelidate() }
  },
  validations () {
    return {
      dataToSend: {
        client: { required },
        tc: { required },
        address: { required },
        ttn: { required },
        orderCost: { required },
        paymentDoc: { required },
        orderDate: { required },
        shippingDate: { required },
        deliveryDate: { required },
        art: { required },
        count: { required }
      }
    }
  },
  data: () => {
    return {
      createData: {
        title: 'Создать заказ'
      },
      status: [
        {
          text: 'К отправке',
          value: 1
        }
      ],
      clientList: [
        {
          text: 'МетталПром',
          value: 1
        }
      ],
      tcList: [
        {
          text: '',
          value: 1
        }
      ],
      dataToSend: {
        client: '',
        tc: '',
        address: '',
        ttn: '',
        orderCost: '',
        paymentDoc: '',
        orderDate: '',
        shippingDate: '',
        deliveryDate: '',
        acceptTc: false,
        acceptClient: false,
        extra: '',
        art: '',
        count: ''
      }
    }
  },
  methods: {
    async sendToServer () {
      const isReady = await this.v$.$validate()

      if (!isReady) {
        console.log('Ошибка!')
      } else {
        console.log('Объект готов к отправке', this.dataToSend)
      }
    }
  }
}
</script>
